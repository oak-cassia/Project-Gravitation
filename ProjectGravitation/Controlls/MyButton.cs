using ProjectGravitation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Speech.Synthesis;

namespace ProjectGravitation.Controlls
{
    public class MyButton : Button
    {
        SpeechSynthesizer speechSynthesizer;

        public static bool IsSpeak = true;
        public MyButton()
        {
            this.Background= Brushes.Black;
            this.Foreground = Brushes.White;
            FontSize = 30;
            this.GotFocus += MyButton_GotFocus;
            this.LostFocus += MyButton_LostFocus;
            speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.SetOutputToDefaultAudioDevice();

            speechSynthesizer.SelectVoice("Microsoft Heami Desktop");
        }

        private void MyButton_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Background = Brushes.Black;
        }

        private void MyButton_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            //버튼의 콘텐트 읽기
            Button button = sender as Button;
            button.Background = Brushes.SkyBlue;
            if (IsSpeak)
            {
                speechSynthesizer.Speak(this.Content.ToString());
                                    
            }
        }
    }
}
