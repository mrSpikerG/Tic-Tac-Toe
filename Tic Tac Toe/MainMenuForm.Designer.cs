
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        public static string FieldSize="3x3";
        public static int id = 0;
        private void InitializeComponent()
        {
            this.Text = "Tic Tac Toe";
            this.BackColor = Color.ForestGreen;
            this.StartPosition = FormStartPosition.Manual;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Width / 2 - this.Width/2, Screen.AllScreens[0].WorkingArea.Height / 2 - this.Height/2);
            this.Icon = new Icon("Resources/icon.ico");


            //
            //      title
            //
            this.title_Label = new Label();
            this.Controls.Add(title_Label);
            this.title_Label.AutoSize = true;
            this.title_Label.Text = "Tic Tac Toe";
            this.title_Label.ForeColor = Color.Lime;
            this.title_Label.BackColor = Color.Transparent;
            this.title_Label.Font = new Font(this.title_Label.Font.FontFamily, 50);
            this.title_Label.Location = new Point(this.ClientSize.Width / 2 - title_Label.Size.Width/2, this.ClientSize.Height/ 2 - title_Label.Size.Height / 2 - this.ClientSize.Height / 3);

            //
            //      buttons
            //
            buttons = new Button[4];
            for (int i = 0; i < 4; i++)
            {
                this.buttons[i] = new Button();
                this.buttons[i].Size = new Size(300, 70);
                this.buttons[i].Location = new Point(this.ClientSize.Width / 2 - buttons[i].Size.Width/2, this.ClientSize.Height / 2 - buttons[i].Size.Height / 2 + 72 * i - this.ClientSize.Height/10);
                this.buttons[i].BackColor = Color.LimeGreen;
                this.buttons[i].ForeColor = Color.OrangeRed;
                this.buttons[i].Click += clickEvent;
                this.Controls.Add(buttons[i]);
            }
            //buttons?


            this.buttons[0].Text = "Play";
            this.buttons[0].Name = "Play";
            this.buttons[0].Font = new Font(this.title_Label.Font.FontFamily, 30);

            this.buttons[1].Text = "Settings";
            this.buttons[1].Name = "Settings";
            this.buttons[1].Font = new Font(this.title_Label.Font.FontFamily, 30);

            this.buttons[2].Text = "Leaderboard";
            this.buttons[2].Name = "Leaderboard";
            this.buttons[2].Font = new Font(this.title_Label.Font.FontFamily, 30);

            this.buttons[3].Text = "Exit";
            this.buttons[3].Name = "Exit";
            this.buttons[3].Font = new Font(this.title_Label.Font.FontFamily, 30);

        }

        public void clickEvent(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "Play":
                    chose_Form = new ChosePlayerForm();
                    chose_Form.Show();
                    break;
                case "Settings":
                    settings_Form = new SettingsForm();
                    settings_Form.Show();
                    break;
                case "LeaderBoard":
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }

        Button[] buttons;
        Label title_Label;
        ChosePlayerForm chose_Form;
        SettingsForm settings_Form;
        #endregion
    }
}

