
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region 
        public static int id = 0;
        private string winner;
        private int iIndex, jIndex;
        private void InitializeComponent()
        {
            this.Text = "Tic Tac Toe";
            this.StartPosition = FormStartPosition.Manual;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = new Bitmap("Resources/InGameMenu.png");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Width / 2 - 100, Screen.AllScreens[0].WorkingArea.Height / 2 - 100);

            this.buttons = new ExtendedButton[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.buttons[i, j] = new ExtendedButton("none");
                    this.buttons[i, j].Click += Button_Click;
                    this.buttons[i, j].Location = new Point(i * 50 + i * 8 + 29, j * 50 + j * 8 + 29);
                    this.buttons[i, j].Text = " ";
                    this.buttons[i, j].Font = new Font(buttons[i, j].Font.FontFamily, 1);
                    this.buttons[i, j].Name = $"{i}{j}";
                    this.buttons[i, j].Hide();
                }
            }


            this.iIndex = (int)char.GetNumericValue(MainMenuForm.FieldSize[0]);
            this.jIndex = (int)char.GetNumericValue(MainMenuForm.FieldSize[2]);
            for (int i = 0; i < iIndex; i++)
            {
                for (int j = 0; j < jIndex; j++)
                {
                    buttons[i, j].Show();
                }
            }
            //  39 16
            this.ClientSize = new Size(
                iIndex * 50 + (iIndex - 1) * 8 + 58,
                jIndex * 50 + (jIndex - 1) * 8 + 58);

            foreach (Button i in buttons)
            {
                this.Controls.Add(i);
            }
        }

        public static bool isCircle = false;
        private void Button_Click(object sender, System.EventArgs e)
        {
            if (isCircle)
            {
                (sender as ExtendedButton).BackgroundImage = new Bitmap("Resources/zero_btn.png");
                (sender as ExtendedButton).Text = "o";
                isCircle = false;
            }
            else
            {

                (sender as ExtendedButton).BackgroundImage = new Bitmap("Resources/cross_btn.png");
                (sender as ExtendedButton).Text = "x";
                isCircle = true;
            }
            if (checkForWin((sender as ExtendedButton).Text, (int)char.GetNumericValue((sender as ExtendedButton).Name[0]), (int)char.GetNumericValue((sender as ExtendedButton).Name[1]), SideCheck.HORIZONTAL) ||
            checkForWin((sender as ExtendedButton).Text, (int)char.GetNumericValue((sender as ExtendedButton).Name[0]), (int)char.GetNumericValue((sender as ExtendedButton).Name[1]), SideCheck.VERTICAL) ||
            checkForWin((sender as ExtendedButton).Text, (int)char.GetNumericValue((sender as ExtendedButton).Name[0]), (int)char.GetNumericValue((sender as ExtendedButton).Name[1]), SideCheck.DIAGONAL1) ||
            checkForWin((sender as ExtendedButton).Text, (int)char.GetNumericValue((sender as ExtendedButton).Name[0]), (int)char.GetNumericValue((sender as ExtendedButton).Name[1]), SideCheck.DIAGONAL2) ||
                     checkForDraw())
            {
                if (!Directory.Exists("Data"))
                {
                    Directory.CreateDirectory("Data");
                }
                File.AppendAllText("Data/winRate.txt", $"{ChosePlayerForm.player1} vs {ChosePlayerForm.player2}\t{iIndex}x{jIndex}\twinner: {this.winner}\n");
                this.Close();
            }


            (sender as Button).Enabled = false;
        }

        private bool checkForWin(string value, int x, int y, SideCheck side)
        {

            int dx = 0, dy = 0, score = 0;
            switch (side)
            {
                case SideCheck.HORIZONTAL:
                    dx = 1;
                    dy = 0;
                    break;
                case SideCheck.VERTICAL:
                    dx = 0;
                    dy = 1;
                    break;
                case SideCheck.DIAGONAL1:
                    dx = 1;
                    dy = 1;
                    break;
                case SideCheck.DIAGONAL2:
                    dx = 1;
                    dy = -1;
                    break;
            }
            try
            {
                while (buttons[x - dx, y - dy].Text == value)
                {
                    x -= dx;
                    y -= dy;
                }
            }
            catch (IndexOutOfRangeException e)
            {

            }
            try
            {
                while (buttons[x, y].Text == value)
                {
                    x += dx;
                    y += dy;
                    score++;
                }
            }
            catch (IndexOutOfRangeException e)
            {

            }
            if (score >= 3)
            {
                
                if(value== "x")
                {
                    this.winner = ChosePlayerForm.player2;
                }
                else
                {
                    this.winner = ChosePlayerForm.player1;
                }
                showWinner(winner);
                return true;
            }
            return false;

        }
        private bool checkForDraw()
        {

            bool isClosed = true;
            for (int i = 0; i < iIndex; i++)
            {
                for (int j = 0; j < jIndex; j++)
                {
                    if (buttons[i, j].Text == " ")
                    {
                        isClosed = false;
                    }
                }
            }
            if (isClosed)
            {
                this.winner = "Ничья!";
                MessageBox.Show(winner);
                return true;
            }
            return false;
        }
        private void showWinner(string winner)
        {
            
            MessageBox.Show($"{winner} победил");
        }

        enum SideCheck
        {
            VERTICAL,
            HORIZONTAL,
            DIAGONAL1,
            DIAGONAL2,
        }




        ExtendedButton[,] buttons;
        #endregion
    }
}