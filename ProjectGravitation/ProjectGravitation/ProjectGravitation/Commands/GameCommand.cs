using ProjectGravitation.Classes;
using ProjectGravitation.Controlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                MainStart(clickedBtn);   // 각 버튼마다 다른 함수를 호출하게 합니다. 
        }

        public void MainStart(Button buttons)
        {
            StackPanel aa = buttons.Parent as StackPanel;//버튼의 부모인 스택패널 buttons에 접근
            aa.Children.Clear();                    //  자식을 지우고  버튼을 추가해주면 됩니다.
            MyButton button1 = new MyButton();
            button1.Content = "1지역";

            aa.Children.Add(button1);
        }

        
    }
}
