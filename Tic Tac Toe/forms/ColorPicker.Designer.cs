﻿
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe.forms
{
    partial class ColorPicker
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
        private int colorR, colorG, colorB, colorA;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Text = "Color picker";


            checkBoxes = new CheckBox[4];
            for (int i = 0; i < 4; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Checked = true;
                checkBoxes[i].Location = new Point(190, 50 * i + 20);
                checkBoxes[i].Click += CheckboxChangedEvent;
            }


            labels = new Label[7];
            for (int i = 0; i < 3; i++)
            {
                labels[i] = new Label();
                // this.trackBars[i].Location = new Point(30, 20);
            }
            labels[0].Text = "R";
            labels[1].Text = "G";
            labels[2].Text = "B";


            labels[0].Location = new Point(25, 40);
            labels[1].Location = new Point(25, 90);
            labels[2].Location = new Point(25, 130);

            for (int i = 3; i < 7; i++)
            {
                labels[i] = new Label();
                labels[i].Text = "0";
                labels[i].AutoSize = true;
                //  this.trackBars[i].Location = new Point(90, 50 * i + 20);
            }
            labels[3].Location = new Point(150, 40);
            labels[4].Location = new Point(150, 90);
            labels[5].Location = new Point(150, 130);
            labels[6].Location = new Point(150, 180);

            trackBars = new TrackBar[4];
            for (int i = 0; i < 4; i++)
            {
                this.trackBars[i] = new TrackBar();
                this.trackBars[i].Location = new Point(40, 50 * i + 20);
                this.trackBars[i].Minimum = 0;
                this.trackBars[i].Maximum = 255;
                this.trackBars[i].Value = 0;
                this.trackBars[i].ValueChanged += ValueChangedEvent;
            }
            this.trackBars[0].Name = "R";
            this.trackBars[1].Name = "G";
            this.trackBars[2].Name = "B";
            this.trackBars[3].Name = "A";


            Button tempButton = new Button();
            tempButton.Enabled = false;

            Bitmap picture = new Bitmap("alpha.png");
            tempButton.BackgroundImage = picture;
            tempButton.Size = new Size(21, 21);
            tempButton.FlatAppearance.BorderSize = 0;
            tempButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            tempButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            tempButton.FlatAppearance.CheckedBackColor = Color.Transparent;
            tempButton.FlatStyle = FlatStyle.Flat;
            tempButton.BackColor = Color.Transparent;
            tempButton.ForeColor = Color.Transparent;
            tempButton.Location = new Point(20, 170);

            /* tempButton.BackgroundImage = new Bitmap("alpha.png");
             tempButton.BackColor = Color.Transparent;
             tempButton.AutoSize = true;
 */
            for (int i = 0; i < 4; i++)
            {
                this.Controls.Add(trackBars[i]);
            }
            for (int i = 0; i < 7; i++)
            {
                this.Controls.Add(labels[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                this.Controls.Add(checkBoxes[i]);
            }
            this.Controls.Add(tempButton);
        }

        private void ValueChangedEvent(object sender, EventArgs e)
        {
            colorR = trackBars[0].Value;
            colorG = trackBars[1].Value;
            colorB = trackBars[2].Value;
            colorA = trackBars[3].Value;

            for (int i = 0; i < 4; i++)
            {
                labels[i + 3].Text = trackBars[i].Value.ToString();
            }

            Color color = Color.FromArgb(255, colorR, colorG, colorB);
            this.BackColor = color;
            MainMenuForm.CustomBack = color;
        }

        private void CheckboxChangedEvent(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                trackBars[i].Enabled = checkBoxes[i].Checked;
            }
        }

        TrackBar[] trackBars;
        Label[] labels;
        CheckBox[] checkBoxes;
        #endregion
    }
}