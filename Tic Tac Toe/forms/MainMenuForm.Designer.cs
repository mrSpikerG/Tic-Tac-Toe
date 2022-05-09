
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
            this.BackgroundImage = new Bitmap("Resources/MainMenu.png");


            //
            //      title
            //
            this.title_Label = new Label();
           /* this.Controls.Add(title_Label);
            this.title_Label.AutoSize = true;
            this.title_Label.Text = "Tic Tac Toe";
            this.title_Label.ForeColor = Color.Lime;
            this.title_Label.BackColor = Color.Transparent;
            this.title_Label.Font = new Font(this.title_Label.Font.FontFamily, 50);
            this.title_Label.Location = new Point(this.ClientSize.Width / 2 - title_Label.Size.Width/2, this.ClientSize.Height/ 2 - title_Label.Size.Height / 2 - this.ClientSize.Height / 3);
*/
            //
            //      buttons
            //
            buttons = new ExtendedButton[4];
            this.buttons[0] = new ExtendedButton("play");
            this.buttons[1] = new ExtendedButton("settings");
            this.buttons[2] = new ExtendedButton("rate");
            this.buttons[3] = new ExtendedButton("exit");
            for (int i = 0; i < 4; i++)
            {
                this.buttons[i].Location = new Point(79-buttons[i].Size.Width, this.ClientSize.Height / 2 - buttons[i].Size.Height / 2 + 72 * i - this.ClientSize.Height/10);
                this.buttons[i].Click += clickEvent;
                this.buttons[i].MouseHover+= hoverEvent;
                this.buttons[i].MouseLeave += leaveEvent;
               
                this.Controls.Add(buttons[i]);
            }

            //
            //      Timers
            //
            this.timerIncrease = new Timer();
            this.timerIncrease.Interval = 20;
            this.timerIncrease.Tick += timerIncreaseEvent;

            this.timerDecrease = new Timer();
            this.timerDecrease.Interval = 20;
            this.timerDecrease.Tick += timerDecreaseEvent;


            //
            //      Buttons config
            //
            //this.buttons[0].Text = "Play";
            this.buttons[0].Name = "0";
            this.buttons[0].Font = new Font(this.title_Label.Font.FontFamily, 30);

          //  this.buttons[1].Text = "Settings";
            this.buttons[1].Name = "1";
            this.buttons[1].Font = new Font(this.title_Label.Font.FontFamily, 30);

          //  this.buttons[2].Text = "Leaderboard";
            this.buttons[2].Name = "2";
            this.buttons[2].Font = new Font(this.title_Label.Font.FontFamily, 30);

           // this.buttons[3].Text = "Exit";
            this.buttons[3].Name = "3";
            this.buttons[3].Font = new Font(this.title_Label.Font.FontFamily, 30);

            this.DoubleBuffered = true;
        }

        private int chosedButton;
        public void clickEvent(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "0":
                    chose_Form = new ChosePlayerForm();
                    chose_Form.Show();
                    break;
                case "1":
                    settings_Form = new SettingsForm();
                    settings_Form.Show();
                    break;
                case "2":
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }
        public void hoverEvent(object sender, EventArgs e)
        {
            timerDecrease?.Stop();
            chosedButton = (int)char.GetNumericValue((sender as ExtendedButton).Name[0]);
            timerIncrease.Start();
        }
        public void leaveEvent(object sender, EventArgs e)
        {
            timerIncrease?.Stop();
            chosedButton = (int)char.GetNumericValue((sender as ExtendedButton).Name[0]);
            timerDecrease.Start();
        }
        public void timerIncreaseEvent(object sender, EventArgs e)
        {
            if (buttons[chosedButton].Location.X < 0)
            {
                buttons[chosedButton].Location = new Point(buttons[chosedButton].Location.X + 5, buttons[chosedButton].Location.Y);
            }
            else
            {
                timerIncrease.Stop();
            }
            this.Invalidate();
        }
        public void timerDecreaseEvent(object sender, EventArgs e)
        {
            if (buttons[chosedButton].Location.X > 79 - buttons[chosedButton].Size.Width)
            {
                buttons[chosedButton].Location = new Point(buttons[chosedButton].Location.X - 5, buttons[chosedButton].Location.Y);
            }
            this.Invalidate();
        }

        ExtendedButton[] buttons;
        Label title_Label;
        ChosePlayerForm chose_Form;
        SettingsForm settings_Form;
        Timer timerIncrease;
        Timer timerDecrease;
        #endregion
    }
}

