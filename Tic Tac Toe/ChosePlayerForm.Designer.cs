
using System;
using System.Drawing;
using System.Windows.Forms;

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
        private void InitializeComponent()
        {
            this.Text = "ChosePlayerForm";
            this.StartPosition = FormStartPosition.Manual;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Width / 2 - this.Width / 2, Screen.AllScreens[0].WorkingArea.Height / 2 - this.Height / 2);


            for (int i = 0; i < 2; i++)
            {
                textBoxes[i] = new TextBox();
                labels[i] = new Label();

                labels[i].Text = $"Имя игрока ({i + 1})";
                labels[i].AutoSize = true;
                labels[i].Font = new Font(this.Font.FontFamily, 20);

                textBoxes[i].Size = new Size(120, 50);

                this.Controls.Add(textBoxes[i]);
                this.Controls.Add(labels[i]);

                labels[i].Location = new Point(this.ClientSize.Width / 2 - labels[i].Size.Width / 2, this.ClientSize.Height / 2 - labels[i].Size.Height / 2 - this.ClientSize.Height / 3 + i * 80);
                textBoxes[i].Location = new Point(this.ClientSize.Width / 2 - textBoxes[i].Size.Width / 2, this.ClientSize.Height / 2 - textBoxes[i].Size.Height / 2 - this.ClientSize.Height / 3 + 40 + i * 80);
            }

            confirm_Button = new Button();
            confirm_Button.Click +=clickEvent;
            confirm_Button.Text = "Подтвердить";
            confirm_Button.AutoSize = true;
            confirm_Button.Font = new Font(this.Font.FontFamily, 20);
            this.Controls.Add(confirm_Button);
            confirm_Button.Location = new Point(this.ClientSize.Width / 2 - confirm_Button.Size.Width / 2, this.ClientSize.Height / 2 - confirm_Button.Size.Height / 2+65);
        }
        public void clickEvent(object sender, EventArgs e)
        {
            game_Form = new GameForm();
            game_Form.Show();
        }



        TextBox[] textBoxes = new TextBox[2];
        Label[] labels = new Label[2];
        Button confirm_Button;
        GameForm game_Form;
        #endregion
    }
}