using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class SettingsForm : Form
    {

        protected bool IsCustom;
        public string FieldSize;
        public SettingsForm()
        {
            InitializeComponent();
            IsCustom = false;
          //  FieldSize = "3x3";
        }
        private void Box_Click(object sender, System.EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == "Свой вариант")
            {
                this.IsCustom = true;
            }
            else
            {
                this.IsCustom = false;
                MainMenuForm.FieldSize = (sender as ComboBox).SelectedItem.ToString(); 
                this.FieldSize = (sender as ComboBox).SelectedItem.ToString();
            }
            renderUpdate();
        }

        private void Button_Hovered(object sender, System.EventArgs e)
        {
            int iIndex = (int)char.GetNumericValue((sender as Button).Name[0]) + 1;
            int jIndex = (int)char.GetNumericValue((sender as Button).Name[2]) + 1;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i < iIndex && j < jIndex)
                    {
                        buttons[i, j].BackColor = Color.Lime;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;

                    }
                }
            }
        }
        private void Button_Clicked(object sender, System.EventArgs e)
        {
            int iIndex = (int)char.GetNumericValue((sender as Button).Name[0]) + 1;
            int jIndex = (int)char.GetNumericValue((sender as Button).Name[2]) + 1;

            if (iIndex > 2 && jIndex > 2)
            {
                renderUpdate();
                this.FieldSize = $"{iIndex}x{jIndex}";
                MainMenuForm.FieldSize = this.FieldSize;
            }
        }
    }
}
