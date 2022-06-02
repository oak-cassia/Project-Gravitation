using ProjectGravitation.Classes;
using ProjectGravitation.Controlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectGravitation.Commands
{
    public class GameCommand : ICommand
    {

        Game _game;

        public event EventHandler CanExecuteChanged;

        public GameCommand(Game game)
        {
            _game = game;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) //인자로 버튼을 받습니다. (버튼 있는 것)
        {
            MyButton clickedBtn = parameter as MyButton; // MyButton 으로 기본 스타일을 정해두었습니다. 버튼기본값 바꾸는 게 어려워서;;
            if (clickedBtn.Content.ToString() == "게임 시작")
            {
                _game.panel = clickedBtn.Parent as StackPanel;
                MainStart(clickedBtn);
            }// 각 버튼마다 다른 함수를 호출하게 합니다. 
            if (clickedBtn.Content.ToString() == "1지역")
                SectorOneStart(clickedBtn);
            if (clickedBtn.Content.ToString() == "동쪽으로 이동"|| clickedBtn.Content.ToString() == "서쪽으로 이동" || clickedBtn.Content.ToString() == "남쪽으로 이동" || clickedBtn.Content.ToString() == "북쪽으로 이동" )
                MoveTreasuerGame(clickedBtn);
            if (clickedBtn.Content.ToString() == "베이스 캠프로 돌아가기") 
                MainStart(clickedBtn);
            if(clickedBtn.Content.ToString() == "얼굴에 입을 맞춘다")
            {
                _game._positivePoint+=3;
                MainStart(clickedBtn);
            }
            if(clickedBtn.Content.ToString() == "나무 가지를 꺾는다")
            {
                _game._negativePoint+=3;
                MainStart(clickedBtn);
            }
            if (clickedBtn.Content.ToString() == "헛기침을 낸다." || clickedBtn.Content.ToString() == "가만히 있는다.")
            {
                EndingN2(clickedBtn);
            }
            if (clickedBtn.Content.ToString()=="...")
            {
                EndingN3();
            }
            if (clickedBtn.Content.ToString() == "눈이 감긴다.")
            {
                EndingN4();
            }
            if (clickedBtn.Content.ToString() == "종료")
            {
                System.Environment.Exit(0);
            }

   
            
            
           Grid grid = _game.panel.Parent as Grid;
           StackPanel buttons=grid.FindName("buttons") as StackPanel;//https://docs.microsoft.com/ko-kr/dotnet/desktop/wpf/advanced/how-to-find-an-element-by-its-name?view=netframeworkdesktop-4.8
           buttons.Focus();
        }

        public void MainStart(Button clickedBtn)
        {
            _game.Text = "어느 지역으로 갈까요?";
            StackPanel panel = clickedBtn.Parent as StackPanel;//버튼의 부모인 스택패널 buttons에 접근
            panel.Children.Clear();                    //  자식을 지우고  버튼을 추가해주면 됩니다.
            MyButton button1 = new MyButton();
            button1.Content = "1지역";
            button1.Command=_game._gameCommand;
            button1.CommandParameter = button1;
            panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "2지역";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button1;
            panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "3지역";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            panel.Children.Add(button3);
        }
        public void SectorOneStart(Button clickedBtn)
        {

            if((_game._negativePoint+_game._positivePoint)==3)
            {
                //호출 엔딩
                if(_game._negativePoint>_game._positivePoint)
                {
                    EndingN();
                }
                else
                {
                    //EndingP
                }
                return;
            }

            if(_game._sectorOneLevel==4)
            {
                _game.Text += "\n클리어 했습니다.";
                return;
            }
            _game._trGame = new TreasureGame(_game,_game._sectorOneLevel);

            _game.Text = "신호찾기 레벨"+_game._sectorOneLevel+" 시작";
            StackPanel panel = clickedBtn.Parent as StackPanel;
            panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "동쪽으로 이동";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "서쪽으로 이동";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button1;
            panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "남쪽으로 이동";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            panel.Children.Add(button3);

            MyButton button4 = new MyButton();
            button4.Content = "북쪽으로 이동";
            button4.Command = _game._gameCommand;
            button4.CommandParameter = button4;
            panel.Children.Add(button4);


        }

        public void MoveTreasuerGame(Button clickedBtn)
        {
            _game._trGame.Move(clickedBtn);

        }
        public void TreasuerGAmeClear()
        {
            _game.Text = "신호 찾기 " + (_game._sectorOneLevel-1) + "레벨 클리어!";
            
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "베이스 캠프로 돌아가기";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }

        public void SectorOneEnd()
        {
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "나무 가지를 꺾는다";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "얼굴에 입을 맞춘다";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button1;
            _game.panel.Children.Add(button2);

        }

        public void EndingN()
        {
            _game.panel.Children.Clear();
            _game.Text = "소리 없이 지평선 끝부터 그림자가 드리웠다." +
                " 순식간에 내가 있는 곳까지 어두워졌다. 심장이 내려 앉았다. 주변엔 이제 아무것도 보이지 않았다";
            MyButton button1 = new MyButton();
            button1.Content = "헛기침을 낸다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "가만히 있는다.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button1;
            _game.panel.Children.Add(button2);
        }

        public void EndingN2(Button button)
        {
            string content = button.Content.ToString();
            if (content == "헛기침을 낸다.")
            {
                _game.Text = "나는 헛기침을 냈다.";
            }
            else
            {
                _game.Text = "나는 가만히 있었다.";
            }

            _game.panel.Children.Clear();

            _game.Text = _game.Text+ "적막이 흘렀다. 나는 손가락 하나 까딱할 수 없었다." +
                "움직이면 모든 게 끝장날 거라는 생각이 들었다. 언제까지 이렇게 서 있어야 할까.";
            MyButton button1 = new MyButton();
            button1.Content = "...";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "...";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button1;
            _game.panel.Children.Add(button2);
        }

        public void EndingN3()
        {
            _game.panel.Children.Clear();
            _game.Text = "불이 켜졌다. 아니 주변이 밝아진 것이 아니었다. 하늘에 무수한 눈동자와 흰자가 나타났다. " +
                "그 거대한 눈동자는 나를 내려봤다. ";
            MyButton button1 = new MyButton();
            button1.Content = "눈이 감긴다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
        public void EndingN4()
        {
            _game.Text = "End";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "종료";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
    }
}
