using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectGravitation.Commands
{
    internal class KeyDownCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        SpeechSynthesizer speechSynthesizer; 

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.SetOutputToDefaultAudioDevice();

            speechSynthesizer.SelectVoice("Microsoft Heami Desktop");
            string text = parameter.ToString();
            
            speechSynthesizer.Speak(text);

        }
    }
}
