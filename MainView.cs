namespace Tetris
{
    public partial class MainViewForm : Form
    {
        private const int WIDTH = 20; 
        private const int HEIGHT = 28; 
        private const int CELL = 25; 

        private int[,] shape = new int[2, 4]; 
        private int[,] gameField = new int[WIDTH, HEIGHT]; 

        private Bitmap bitField = new Bitmap(CELL * (WIDTH) + 1, CELL * (HEIGHT) + 1);
        private Graphics gameGraphics;

        private Color GameBackgroundColor { get; set; } = Color.Black;
        private Brush FieldColor { get; set; } = new SolidBrush(Color.Green);
        private Brush ShapeColor { get; set; } = new SolidBrush(Color.AliceBlue);

        private int defaultGameSpeed = 200;
        private int currentGameSpeed = 200;
        private int recordScore = 0;

        Random random = new Random(DateTime.Now.Millisecond);

        private int GameScore { get; set; }

        public MainViewForm()
        {
            InitializeComponent();
            bestScoreTextbox.Text = Properties.Settings.Default.BestScore.ToString();
            BackColor = Properties.Settings.Default.BackgroundColor;
            gameGraphics = Graphics.FromImage(bitField);
            StartGame();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GameTimer.Enabled == false)
            {
                StartGame();
            }
            else if(GameTimer.Enabled == true)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            if (GameScore > 0)
            {
                GameScore = 0;
                recordScore = 0;
                ScoreBox.Text = GameScore.ToString();
            }
            GameTimer.Interval = defaultGameSpeed;
            losingLabelText.Visible = false;
            gameField = new int[WIDTH, HEIGHT];
            gameGraphics = Graphics.FromImage(bitField);
            SetBorderBitField();
            FillField();
            SetShape();
            GameTimer.Start();
        }

        private void SetBorderBitField()
        {
            for (int i = 0; i < WIDTH; i++)
            {
                gameField[i, HEIGHT - 1] = 1;
            }
            for (int i = 0; i < HEIGHT; i++)
            {
                gameField[0, i] = 1;
                gameField[WIDTH - 1, i] = 1;
            }
        }
        
        private void SetShape()
        {
            ShapeColor = new SolidBrush(Color.FromArgb(random.Next(10, 256), random.Next(10, 256), random.Next(10, 256)));
            if (GameTimer.Interval == 1)
            {
                GameTimer.Interval = currentGameSpeed;
            }
            switch (random.Next(7)) //Âûáèðàåì ðàíäîìíóþ ôèãóðó èç 7 âîçìîæíûõ
            {
                case 0:
                    shape = new int[,]
                    {
                        { 2, 3, 4, 5 },
                        { 7, 7, 7, 7 }
                    };
                    break;
                case 1:
                    shape = new int[,]
                    {
                        { 2, 3, 2, 3 },
                        { 7, 7, 8, 8 }
                    };
                    break;
                case 2:
                    shape = new int[,]
                    {
                        { 2, 3, 4, 4 },
                        { 7, 7, 7, 8 }
                    };
                    break;
                case 3:
                    shape = new int[,]
                    {
                        { 2, 3, 4, 4 },
                        { 7, 7, 7, 6 }
                    };
                    break;
                case 4:
                    shape = new int[,]
                    {
                        { 3, 3, 4, 4 },
                        { 6, 7, 7, 8 }
                    };
                    break;
                case 5:
                    shape = new int[,]
                    {
                        { 3, 3, 4, 4 },
                        { 8, 7, 7, 6 }
                    }; break;
                case 6:
                    shape = new int[,]
                    {
                        { 3, 4, 4, 4 },
                        { 7, 6, 7, 8 }
                    }; break;
            }
        }
        private void FillField()
        {
            gameGraphics.Clear(GameBackgroundColor); //Î÷èùàåì èãðîâîå ïîëå, çàäàåì öâåò
            for (int i = 0; i < WIDTH; i++) //ðèñóåì ãðàíèöû è óïàâøèå ôèãóðû
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    if (gameField[i, j] == 1) //Åñëè êëåòêà ïîëÿ ñóùåñòâóåò
                    {
                        Rectangle rectangle = new Rectangle(i * CELL, j * CELL, CELL, CELL);
                        gameGraphics.FillRectangle(FieldColor, rectangle); //Ðèñóåì â ýòîì ìåñòå êâàäðàòèê
                        gameGraphics.DrawRectangle(Pens.Black, rectangle);
                        
                    }
                }
            }
            for (int i = 0; i < 4; i++) //Ðèñóåì ïàäàþùóþ ôèãóðó
            {
                Rectangle rectangle = new Rectangle(shape[1, i] * CELL, shape[0, i] * CELL, CELL, CELL);
                gameGraphics.FillRectangle(ShapeColor, rectangle);
                gameGraphics.DrawRectangle(Pens.Black, rectangle);
            }
            GameFieldPictureBox.Image = bitField;
        }
        
        private bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
            {
                if(shape[1, i] >= WIDTH || shape[0, i] >= HEIGHT || shape[1, i] <= 0 || shape[0, i] <= 0 || gameField[shape[1, i], shape[0, i]] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    for (int i = 0; i < 4; i++)
                    {
                        shape[1, i]--; //Ñíà÷àëà ñäâèãàåì êîîðäèíàòû âñåõ êóñî÷êîâ ôèãóðû íà 1 âëåâî ïî îñè ÎÕ
                    }
                    if (FindMistake()) //Åñëè ïîñëå ýòîãî íàøëàñü îøèáêà
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            shape[1, i]++; //Âîçâðàùàåì ôèãóðó íà ìåñòî
                        }
                    }
                    break;
                case Keys.Right:
                    for (int i = 0; i < 4; i++)
                    {
                        shape[1, i]++; //Ñäâèãàåì êîîðäèíàòû âñåõ êóñî÷êîâ ôèãóðû íà 1 âïðàâî 
                    }

                    if (FindMistake())
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            shape[1, i]--;
                        }
                    }
                    break;
                case Keys.Up:
                    int[,] shapeT = new int[2, 4];
                    Array.Copy(shape, shapeT, shapeT.Length); // Ñîçäàäèì êîïèþ ôèãóðêè, ÷òîáû â ñëó÷àå, êîãäà ïîñëå ïåðåâîðîòà íà ïîëå íàéäåòñÿ îøèáêà, íå ïåðåâîðà÷èâàòü å¸ îáðàòíî, à ïðîñòî âîññòàíîâèòü êîïèþ
                    int maxX = 0;
                    int maxY = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (shape[0,i] > maxY)
                        {
                            maxY = shape[0, i];
                        }
                        if (shape[1,i] > maxX)
                        {
                            maxX = shape[1, i];
                        }
                    } //Íàéäåì ìàêñèìàëüíûå êîîðäèíàòû çíà÷åíèÿ ôèãóðû ïî Õ è ïî Y

                    for (int i = 0; i < 4; i++)
                    {
                        int temp = shape[0, i];
                        shape[0, i] = maxY - (maxX - shape[1, i]) - 1;
                        shape[1, i] = maxX - (3 - (maxY - temp)) + 1;
                    } // Ïåðåâåðíåì ôèãóðó

                    if (FindMistake())
                    {
                        Array.Copy(shapeT, shape, shape.Length);
                    }
                    break;
                case Keys.Down:
                    currentGameSpeed = GameTimer.Interval;
                    GameTimer.Interval = 1;                    
                    break;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameField[7,3] == 1)
            {
                if (GameScore > Properties.Settings.Default.BestScore)
                {
                    Properties.Settings.Default.BestScore = GameScore;
                    Properties.Settings.Default.Save();
                    bestScoreTextbox.Text = GameScore.ToString();
                }
                GameTimer.Stop();
                losingLabelText.Visible = true;
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                shape[0, i]++;//Ñìåñòèòü ôèãóðó âíèç
            }

            if (FindMistake())
            {
                for (int i = 0; i < 4; i++)
                {
                    gameField[shape[1, i], --shape[0, i]]++;
                }
                SetShape();
            } //Åñëè íàøëàñü îøèáêà, òî ïåðåíåñòè ôèãóðó íà 1 êëåòêó ââåðõ, ñîõðàíèòü è ñîçäàòü íîâóþ ôèãóðó

            for (int i = HEIGHT - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, gameField.GetLength(0)).Select(j => gameField[j, i]).ToArray() where t == 1 select t).Count(); // Êîëè÷åñòâî çàïîëíåííûõ ïîëåé â ðÿäó
                if (cross == WIDTH)
                {
                    for (int k = i; k > 1; k--)
                    {
                        for (int l = 1; l < WIDTH - 1; l++)
                        {
                            gameField[l, k] = gameField[l, k - 1];
                        }                            
                    }
                    GameScore += 10;
                    recordScore += 10;
                    SetRecordScore();
                    ScoreBox.Text = GameScore.ToString();
                    SetGameSpeed();
                    FieldColor = new SolidBrush(Color.FromArgb(random.Next(10, 256), random.Next(10, 256), random.Next(10, 256)));
                    
                }           
            } //Ïðîâåðêà íà çàïîëíåííîñòü ðÿäîì, åñëè íàøëèñü ðÿäû, â êîòîðûõ âñå êëåòêè çàïîëíåíû, ñìåñòèòü âñå ðÿäû, êîòîðûå íàõîäÿòñÿ âûøå óáðàííîé ëèíèè, íà 1 âíèç
            FillField();  
        }

        private void chooseBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)//Ñîáûòèå èç ìåíþ, îòêðûâàåò îêíî ñ âûáîðîì öâåòà
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                BackColor = ColorPicker.Color;
                Properties.Settings.Default.BackgroundColor = ColorPicker.Color;
                Properties.Settings.Default.Save();
            }
        }
        private void SetGameSpeed() //Óñòàíîâêà ñêîðîñòè èãðû êàê óðîâåíü ñëîæíîñòè
        {
            currentGameSpeed -= 10;
            GameTimer.Interval = currentGameSpeed;
        }
        private void SetRecordScore()
        {

        }
    }
}

