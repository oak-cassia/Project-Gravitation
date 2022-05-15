using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectGravitation.Controlls
{
    public class MyButton : Button
    {
        public MyButton()
        {
            this.Background= Brushes.Black;
            this.Foreground = Brushes.White;
            FontSize = 30;
        }
    }
}
