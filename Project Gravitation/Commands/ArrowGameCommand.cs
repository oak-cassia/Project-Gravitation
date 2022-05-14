using Project_Gravitation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project_Gravitation.Commands
{
    public class ArrowGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Arrows _arrows;
        public ArrowGameCommand(Arrows arrows)
        {
            _arrows = arrows;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_arrows.Text.Length == 0)
                return;
            Button btn = parameter as Button;
            

            if (btn.Content.ToString()=="UP")
            {
                if(_arrows.Text[0]== '↑')
                {
                    _arrows.Text = _arrows.Text.Substring(1);
                    
                }

            }
            else if (btn.Content.ToString() == "DOWN")
            {
                if (_arrows.Text[0] == '↓')
                {
                    _arrows.Text = _arrows.Text.Substring(1);

                }

            }
            else if (btn.Content.ToString() == "LEFT")
            {
                if (_arrows.Text[0] == '←')
                {
                    _arrows.Text = _arrows.Text.Substring(1);

                }

            }
            else if (btn.Content.ToString() == "RIGHT")
            {
                if (_arrows.Text[0] == '→')
                {
                    _arrows.Text = _arrows.Text.Substring(1);

                }

            }

        }
    }
}
