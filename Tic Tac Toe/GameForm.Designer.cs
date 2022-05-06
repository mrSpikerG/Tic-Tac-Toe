
using System;
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public static int id = 0;
        private int iIndex, jIndex;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Text = "sizeble";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Width / 2 - 100, Screen.AllScreens[0].WorkingArea.Height / 2 - 100);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;

            this.BackColor = Color.AliceBlue;


            buttons = new Button[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttons[i, j] = new Button();
                    //buttons[i].BackColor = Color.Black;
                    buttons[i, j].Size = new Size(30, 30);
                    buttons[i, j].Click += Button_Click;
                    buttons[i, j].Location = new Point(i * 30, j * 30);
                    buttons[i, j].Text = " ";
                    buttons[i, j].Name = $"{i}{j}";
                    buttons[i, j].Hide();
                }
            }


            iIndex = (int)char.GetNumericValue(MainMenuForm.FieldSize[0]);
            jIndex = (int)char.GetNumericValue(MainMenuForm.FieldSize[2]);
            for (int i = 0; i < iIndex; i++)
            {
                for (int j = 0; j < jIndex; j++)
                {
                    buttons[i, j].Show();
                }
            }


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
                (sender as Button).ForeColor = Color.CornflowerBlue;
                (sender as Button).Text = "o";
                isCircle = false;
            }
            else
            {

                (sender as Button).ForeColor = Color.Red;
                (sender as Button).Text = "x";
                isCircle = true;
            }
            checkForWin((sender as Button).Text, (int)char.GetNumericValue((sender as Button).Name[0]), (int)char.GetNumericValue((sender as Button).Name[1]),SideCheck.HORIZONTAL);
            checkForWin((sender as Button).Text, (int)char.GetNumericValue((sender as Button).Name[0]), (int)char.GetNumericValue((sender as Button).Name[1]),SideCheck.VERTICAL);
            checkForWin((sender as Button).Text, (int)char.GetNumericValue((sender as Button).Name[0]), (int)char.GetNumericValue((sender as Button).Name[1]),SideCheck.DIAGONAL1);
            checkForWin((sender as Button).Text, (int)char.GetNumericValue((sender as Button).Name[0]), (int)char.GetNumericValue((sender as Button).Name[1]),SideCheck.DIAGONAL2);

            checkForDraw();
            (sender as Button).Enabled = false;
        }

        private void checkForWin(string value, int x, int y, SideCheck side)
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
            }catch(IndexOutOfRangeException e)
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
                showWinner(value);

        }
        private void checkForDraw()
        {

            bool isClosed = true;
            for (int i = 0; i < iIndex; i++)
            {
                for (int j = 0; j < jIndex; j++)
                {
                    if(buttons[i,j].Text ==" ")
                    {
                        isClosed = false;
                    }
                }
            }
            if(isClosed)
                MessageBox.Show($"Ничья!");
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




        Button[,] buttons;
        #endregion
    }
}