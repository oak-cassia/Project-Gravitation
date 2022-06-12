using ProjectGravitation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Speech.Synthesis;

namespace ProjectGravitation.Classes
{
    public class Game : INotifyPropertyChanged
    {
        private string _text;//데이터 바인딩으로 이 변수 변경 시 보여지는 스택패널의 텍스트 변경
        SpeechSynthesizer speechSynthesizer;
        public StackPanel panel;
        public TreasureGame _trGame; //1지역 게임
        
        public event PropertyChangedEventHandler PropertyChanged;
        public int _positivePoint { get; set; } //프로퍼티 다섯 개로 진행사항 관리하면 세이브 로드 구현 가능
        public int _negativePoint { get; set; }
        public int _sectorOneLevel { get; set; }
        public int _sectorTwoLevel { get; set; }
        public int _sectorThreeLevel { get; set; }

        public int _startCount = 0;
        public GameCommand _gameCommand { get; set; }//버튼 클릭 시 호출되는 함수들 구현

        /*2지역 추가*/
        public int _Alien_Community { get; set; }
        public int Love { get; set; } // 성향 결정 1; 보수 받으면 2; 스토리 끝날 시 3;
        public int Friendship { get; set; }
        public int Angry { get; set; }

        public int Quiz { get; set; }
        public AlienGame _alGame;
        //2지역

        public SurvivorGame _sgGame;


        public string Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged(nameof(Text)); }
        }
        public void NotifyPropertyChanged(string propName)//Text 변경 시 호출
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            //speechSynthesizer.Speak(Text);
        }
        public Game()
        {
            speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.SetOutputToDefaultAudioDevice();

            speechSynthesizer.SelectVoice("Microsoft Heami Desktop");

            _positivePoint = 0;
            _negativePoint = 0;
            _sectorOneLevel = 1;
            _sectorTwoLevel = 1;
            _sectorThreeLevel = 1;
            _gameCommand = new GameCommand(this);

            /*2지역*/
            _Alien_Community = 1;
            Love = 0;
            Angry = 0;
            Friendship = 0;
            Quiz = 0;
            /*2지역*/

            _sgGame = new SurvivorGame(this);



            if (_startCount == 0)
            {
                _text = "S를 누르면 소리를 끄고 킬 수 있습니다.\n D를 누른 후 방향키로 선택지를 고르고 스페이스 바로 선택할 수 있습니다.. F를 누르면 텍스트를 읽습니다. \n ";
                speechSynthesizer.Speak(_text);
                _startCount++;
            }
        }

    }
}
