namespace Tetris
{
    public partial class MainViewForm : Form
    {
        private const int WIDTH = 20; //Ширина игрового поля
        private const int HEIGHT = 28; //Высота игрового поля
        private const int CELL = 25; //Размер игровой клетки

        private int[,] shape = new int[2, 4]; //Массив для хранения падающей фигуры
        private int[,] gameField = new int[WIDTH, HEIGHT]; //Массив для хранения игрового поля

        private Bitmap bitField = new Bitmap(CELL * (WIDTH) + 1, CELL * (HEIGHT) + 1);
        private Graphics gameGraphics; //Для рисования игрового поля на PictureBox

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
            switch (random.Next(7)) //Выбираем рандомную фигуру из 7 возможных
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
            gameGraphics.Clear(GameBackgroundColor); //Очищаем игровое поле, задаем цвет
            for (int i = 0; i < WIDTH; i++) //рисуем границы и упавшие фигуры
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    if (gameField[i, j] == 1) //Если клетка поля существует
                    {
                        Rectangle rectangle = new Rectangle(i * CELL, j * CELL, CELL, CELL);
                        gameGraphics.FillRectangle(FieldColor, rectangle); //Рисуем в этом месте квадратик
                        gameGraphics.DrawRectangle(Pens.Black, rectangle);
                        
                    }
                }
            }
            for (int i = 0; i < 4; i++) //Рисуем падающую фигуру
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
                        shape[1, i]--; //Сначала сдвигаем координаты всех кусочков фигуры на 1 влево по оси ОХ
                    }
                    if (FindMistake()) //Если после этого нашлась ошибка
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            shape[1, i]++; //Возвращаем фигуру на место
                        }
                    }
                    break;
                case Keys.Right:
                    for (int i = 0; i < 4; i++)
                    {
                        shape[1, i]++; //Сдвигаем координаты всех кусочков фигуры на 1 вправо 
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
                    Array.Copy(shape, shapeT, shapeT.Length); // Создадим копию фигурки, чтобы в случае, когда после переворота на поле найдется ошибка, не переворачивать её обратно, а просто восстановить копию
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
                    } //Найдем максимальные координаты значения фигуры по Х и по Y

                    for (int i = 0; i < 4; i++)
                    {
                        int temp = shape[0, i];
                        shape[0, i] = maxY - (maxX - shape[1, i]) - 1;
                        shape[1, i] = maxX - (3 - (maxY - temp)) + 1;
                    } // Перевернем фигуру

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
                shape[0, i]++;//Сместить фигуру вниз
            }

            if (FindMistake())
            {
                for (int i = 0; i < 4; i++)
                {
                    gameField[shape[1, i], --shape[0, i]]++;
                }
                SetShape();
            } //Если нашлась ошибка, то перенести фигуру на 1 клетку вверх, сохранить и создать новую фигуру

            for (int i = HEIGHT - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, gameField.GetLength(0)).Select(j => gameField[j, i]).ToArray() where t == 1 select t).Count(); // Количество заполненных полей в ряду
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
            } //Проверка на заполненность рядом, если нашлись ряды, в которых все клетки заполнены, сместить все ряды, которые находятся выше убранной линии, на 1 вниз
            FillField();  
        }

        private void chooseBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)//Событие из меню, открывает окно с выбором цвета
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                BackColor = ColorPicker.Color;
                Properties.Settings.Default.BackgroundColor = ColorPicker.Color;
                Properties.Settings.Default.Save();
            }
        }
        private void SetGameSpeed() //Установка скорости игры как уровень сложности
        {
            currentGameSpeed -= 10;
            GameTimer.Interval = currentGameSpeed;
        }
        private void SetRecordScore()
        {

        }
    }
}

