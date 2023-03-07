namespace Tetris
{
    partial class MainViewForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameFieldPictureBox = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.ScoreBox = new System.Windows.Forms.TextBox();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.losingLabelText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bestScoreTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameFieldPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameFieldPictureBox
            // 
            this.GameFieldPictureBox.Location = new System.Drawing.Point(12, 48);
            this.GameFieldPictureBox.Name = "GameFieldPictureBox";
            this.GameFieldPictureBox.Size = new System.Drawing.Size(543, 720);
            this.GameFieldPictureBox.TabIndex = 0;
            this.GameFieldPictureBox.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 200;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // ScoreBox
            // 
            this.ScoreBox.Enabled = false;
            this.ScoreBox.Font = new System.Drawing.Font("Kroftsmann", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreBox.Location = new System.Drawing.Point(561, 48);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Size = new System.Drawing.Size(188, 38);
            this.ScoreBox.TabIndex = 1;
            this.ScoreBox.Text = "Score";
            this.ScoreBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.chooseBackgroundColorToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(60, 24);
            this.Menu.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(262, 26);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // chooseBackgroundColorToolStripMenuItem
            // 
            this.chooseBackgroundColorToolStripMenuItem.Name = "chooseBackgroundColorToolStripMenuItem";
            this.chooseBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(262, 26);
            this.chooseBackgroundColorToolStripMenuItem.Text = "Choose background color";
            this.chooseBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.chooseBackgroundColorToolStripMenuItem_Click);
            // 
            // losingLabelText
            // 
            this.losingLabelText.AutoSize = true;
            this.losingLabelText.BackColor = System.Drawing.Color.Transparent;
            this.losingLabelText.Font = new System.Drawing.Font("Kroftsmann", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.losingLabelText.ForeColor = System.Drawing.Color.Firebrick;
            this.losingLabelText.Location = new System.Drawing.Point(96, 372);
            this.losingLabelText.Name = "losingLabelText";
            this.losingLabelText.Size = new System.Drawing.Size(353, 60);
            this.losingLabelText.TabIndex = 6;
            this.losingLabelText.Text = "GAME OVER";
            this.losingLabelText.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bestScoreTextbox);
            this.groupBox1.Location = new System.Drawing.Point(561, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Best score";
            // 
            // bestScoreTextbox
            // 
            this.bestScoreTextbox.Enabled = false;
            this.bestScoreTextbox.Font = new System.Drawing.Font("Kroftsmann", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bestScoreTextbox.Location = new System.Drawing.Point(6, 25);
            this.bestScoreTextbox.Name = "bestScoreTextbox";
            this.bestScoreTextbox.Size = new System.Drawing.Size(176, 38);
            this.bestScoreTextbox.TabIndex = 2;
            this.bestScoreTextbox.Text = "Best score";
            this.bestScoreTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(761, 780);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.losingLabelText);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.GameFieldPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(779, 827);
            this.MinimumSize = new System.Drawing.Size(779, 827);
            this.Name = "MainViewForm";
            this.Text = "TetriZzz";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameFieldPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox GameFieldPictureBox;
        private System.Windows.Forms.Timer GameTimer;
        private TextBox ScoreBox;
        private ColorDialog ColorPicker;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem chooseBackgroundColorToolStripMenuItem;
        private Label losingLabelText;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox bestScoreTextbox;
    }
}