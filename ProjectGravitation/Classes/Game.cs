using ProjectGravitation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectGravitation.Classes
{
    public class Game : INotifyPropertyChanged
    {
        string _text;
        public StackPanel panel;

        public TreasureGame _trGame;


        public string Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged(nameof(Text)); }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public int _positivePoint { get; set; } //프로퍼티 다섯 개로 진행사항 관리하면 세이브 로드 가능할지도??
        public int _negativePoint { get; set; }
        public int _sectorOneLevel { get; set; }
        public int _sectorTwoLevel { get; set; }
        public int _sectorThreeLevel { get; set; }
        public GameCommand _gameCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Game()
        {
            _positivePoint = 0;
            _negativePoint = 0;
            _sectorOneLevel = 1;
            _sectorTwoLevel = 1;
            _sectorThreeLevel = 1;
            _gameCommand = new GameCommand(this);
            _text = "게임을 시작할 까요?";

             
        }

    }
}
