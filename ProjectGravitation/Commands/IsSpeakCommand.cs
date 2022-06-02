using ProjectGravitation.Controlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectGravitation.Commands
{
    internal class IsSpeakCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (MyButton.IsSpeak)
                MyButton.IsSpeak = false;
            else
                MyButton.IsSpeak = true;
        }
    }
}
