using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe.elements
{
    class ExtendedTextBox : TextBox
    {
        public ExtendedTextBox()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw 
                   //ControlStyles.UserPaint

                     , true);
            //this.BackColor = Color.Transparent;
          
            this.BorderStyle = BorderStyle.FixedSingle;

        }
    }
}
