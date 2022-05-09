using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    class ExtendedButton : Button
    {
        public ExtendedButton()
        {
        }

        public ExtendedButton(string name)
        {
            Bitmap picture = new Bitmap($"Resources/{name}_btn.png");
            this.BackgroundImage = picture ;
            this.Size = new Size(picture.Size.Width, picture.Size.Height);
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor= Color.Transparent ;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
            
        }
    }
}
