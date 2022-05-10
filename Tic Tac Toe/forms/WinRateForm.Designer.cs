
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tic_Tac_Toe.forms
{
    partial class WinRateForm
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
            this.Text = "Rating";



            if (Directory.Exists("Data"))
            {
                string temp = File.ReadAllText("Data/winRate.txt");
                string[] allGames = temp.Split('\n');

                int size = allGames.Length;
                if (size> 10)
                {
                    size = 10;
                }
                this.labels = new Label[size];
                for(int i = 0; i < size; i++)
                {
                    labels[i] = new Label();
                    labels[i].Text = allGames[allGames.Length - i - 1];
                    labels[i].Location = new Point(30, i * 30);
                    labels[i].AutoSize = true;
                    //labels[i]
                    this.Controls.Add(labels[i]);
                }
            
            }


        }

        Label[] labels;

        #endregion
    }
}