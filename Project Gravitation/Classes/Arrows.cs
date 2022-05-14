using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Project_Gravitation.Commands;
namespace Project_Gravitation.Classes
{
    public class Arrows : INotifyPropertyChanged
    {

     
        public ArrowGameCommand arrowGameCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        string text;
        public string Text 
        {
            get { return text; }
            set { text = value; NotifyPropertyChanged(nameof(Text)); } 
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public Arrows()
        {
            arrowGameCommand = new ArrowGameCommand(this);
            int level = 1;
            switch (level)
            {
                case 1:
                    ArrowLevel1();
                    break;
                case 2:
                    break;
                    
                case 3:
                    break;
            }
        }
        void ArrowLevel1()
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int temp = random.Next(4);
                switch(temp)
                {
                    case 0:
                        Text += "↑";
                        break;
                    case 1:
                        Text += "↓";
                        break;
                    case 2:
                        Text += "←";
                        break;
                    case 3:
                        Text += "→";
                        break;
                }
            }
        }
    }
}
