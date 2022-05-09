
using System;
using System.Drawing;
using System.Windows.Forms;
using Tic_Tac_Toe.elements;

namespace Tic_Tac_Toe
{
    partial class ChosePlayerForm
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
        public static string player1, player2;
        private void InitializeComponent()
        {
            this.Text = "ChosePlayerForm";
            this.StartPosition = FormStartPosition.Manual;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Width / 2 - this.Width / 2, Screen.AllScreens[0].WorkingArea.Height / 2 - this.Height / 2);
            this.BackgroundImage = new Bitmap("Resources/ChoseMenu.png");

            for (int i = 0; i < 2; i++)
            {
                textBoxes[i] = new ExtendedTextBox();
                textBoxes[i].Size = new Size(130, 50);

                this.Controls.Add(textBoxes[i]);
            }



           // TextBox box = new TextBox();
           // box.BorderStyle = BorderStyle.None;
           // this.Controls.Add(box);











            textBoxes[0].Location = new Point(40, 100);
            textBoxes[1].Location = new Point(325, 100);

            confirm_Button = new ExtendedButton("confirm");
            confirm_Button.Click += clickEvent;
            //confirm_Button.Text = "Подтвердить";
            //  confirm_Button.AutoSize = true;

            //confirm_Button.Font = new Font(this.Font.FontFamily, 20);
            this.Controls.Add(confirm_Button);
            confirm_Button.Location = new Point(this.ClientSize.Width - confirm_Button.Size.Width - 30, this.ClientSize.Height - confirm_Button.Size.Height - 30);
        }
        public void clickEvent(object sender, EventArgs e)
        {

            if (textBoxes[0].Text.Length > 2 && textBoxes[1].Text.Length > 2)
            {

                player1 = textBoxes[0].Text;
                player2 = textBoxes[1].Text;

                game_Form = new GameForm();
                game_Form.Show();
            }
        }



        ExtendedTextBox[] textBoxes = new ExtendedTextBox[2];
        Label[] labels = new Label[2];
        ExtendedButton confirm_Button;
        GameForm game_Form;
        #endregion
    }
}