using ProjectGravitation.Controlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectGravitation.Commands
{
    internal class TextSpeakCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        SpeechSynthesizer speechSynthesizer;
        int speekCount=0;
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
            
            if(MyButton.IsSpeak)
            {
                speechSynthesizer.Speak(text);
                speekCount = 0;
            }
            else
            {
                speekCount++;
                if (speekCount == 3)
                {
                    MyButton.IsSpeak = true;
                    speechSynthesizer.Speak(text);
                    speekCount = 0;
                }
            }

        }
    }
}
