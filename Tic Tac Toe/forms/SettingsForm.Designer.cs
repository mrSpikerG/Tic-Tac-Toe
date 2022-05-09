
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Settings";


            //
            //      Labels
            //
            choseSize_Label = new Label();
            choseSize_Label.Text = "Chose your size";
            choseSize_Label.Location = new Point(0, 100);
            choseSize_Label.Font = new Font(this.choseSize_Label.Font.FontFamily, 15);
            choseSize_Label.AutoSize = true;

            size_Label = new Label();

            //  
            //      comboBox 
            //
            this.comboBox = new ComboBox();
            this.comboBox.Items.Add("3x3");
            this.comboBox.Items.Add("6x6");
            this.comboBox.Items.Add("9x9");
            this.comboBox.Items.Add("Свой вариант");
            this.comboBox.SelectedIndex = 0;
            this.comboBox.Location = new Point(choseSize_Label.Size.Width + 10, 100 + choseSize_Label.Size.Height);
            this.comboBox.Size = new Size(150, 30);


            this.comboBox.SelectedIndexChanged += Box_Click;


            this.Controls.Add(comboBox);
            this.Controls.Add(choseSize_Label);
            this.Controls.Add(size_Label);

            //init excel
            buttons = new Button[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = $"{i} {j}";
                    buttons[i, j].Size = new Size(30, 30);
                    buttons[i, j].Enabled = false;
                    buttons[i, j].Hide();
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].MouseHover += Button_Hovered;
                    buttons[i, j].Click += Button_Clicked;
                    buttons[i, j].Location = new Point(i * 30 + 400, j * 30);
                    this.Controls.Add(buttons[i, j]);
                }
            }

        }

        public void renderUpdate()
        {
            
            size_Label.Text = $"Size: {FieldSize}";
            size_Label.Location = new Point(100, 20);
            size_Label.Font = new Font(this.choseSize_Label.Font.FontFamily, 15);
            size_Label.AutoSize = true;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.IsCustom)
                    {
                        buttons[i, j].Enabled = true;
                        buttons[i, j].Show();
                    }
                    else
                    {
                        buttons[i, j].Enabled = false;
                        buttons[i, j].Hide();
                    }
                }
            }

        }


        Button[,] buttons;

        ComboBox comboBox;
        Label choseSize_Label;
        Label size_Label;
        #endregion
    }
}