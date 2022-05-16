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
            _game._trGame = new TreasureGame(_game,_game._sectorOneLevel);

            _game.Text = "신호기를 찾자 가까워질 수록 소리가 많이 날 것이다.";
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
            _game.Text = "신호 찾기 " + _game._sectorOneLevel + "레벨 클리어!";
            _game._sectorOneLevel++;
        }
        
    }
}
