using ProjectGravitation.Controlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravitation.Classes
{
    public class SurvivorGame
    {
        Game _game;

        public SurvivorGame(Game game)
        {
            _game = game;
        }

        public void Storm()
        {
            _game.Text = "모래폭풍이 다가오고 있다. 큼지막한 돌맹이들도 보인다.오른쪽에는 큰 건물이 보여 숨을수 있다. 왼쪽에는 지하벙커가 있어 숨을수 있다.그냥 모래폭풍을 지나갈수도 있다 어떻게 할까";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "오른쪽 건물로 간다";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "왼쪽 벙커로 간다";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "그냥 폭풍을 뚫고 간다";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);
        }
        public void Building()
        {
            _game.Text = "거친 모래폭풍에 건물이 무너져서 사망";
            _game.panel.Children.Clear();

            MyButton button = new MyButton();
            button.Content = "처음으로 돌아간다.";
            button.Command = _game._gameCommand;
            button.CommandParameter = button;
            _game.panel.Children.Add(button);
        }
        public void Stone()
        {
            _game.Text = "커다란 돌멩이, 아니 바위가 날아와 맞아서 사망.";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "처음으로 돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }        
        public void Bunker()
        {
            _game.Text = "모래 폭풍이 지나간후 벙커에서 나와 다시 걷기 시작했다. 걷다 보니 배가 고프다. 주변을 둘러보니 낡고 수상한 우주선이 보인다 어떻게 할까";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "바로 우주선을 연다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "우주선 주변을 탐색하자.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "무시하고 갈길 가자";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);
        }
        public void Trap()
        {
            _game.Text = "아뿔사 우주선 주변에 설치해둔 덫을 밟았다. 그대로 사망";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "처음으로 돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
        public void Pass()
        {
            _game.Text = "수상한 우주선을 뒤로하고 걷다보니 아무것도 없는 길이 계속된다. 배가 고파서 사망";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "처음으로 돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
        public void Food()
        {
            _game.Text = "우주선을 열어보니 먼저 온 사람들의 흔적들이 있다. 남기고 간 음식들도 있다 어떻게 할까";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "몰라 배고프니까 일단 먹자.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "신중하게 유통기한을 보고 먹자.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "흠..우주선을 좀더 둘러볼까?";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);
        }
        public void Colic()
        {
            _game.Text = "아이고 배야 다 유통기한이 지난 음식이잖아? 복통으로 사망";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "처음으로 돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
        public void Hungry()
        {
            _game.Text = "신중하게 보니 다 유통기한이 지난 음식들이군 먹을게 없네. 배가 고파서 사망";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "처음으로 돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
        public void Search()
        {
            _game.Text = "우주선을 둘러보니 유통기한이 많이 남은 음식들이 있다.맛있게 먹고 좀 더 둘러보니 농사를 지을수 있게 농기구들과 많은 씨앗들이 있다. 가지고 돌아가자. 어떻게 돌아갈까?";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "탐사 로버가 있네 타고 가자.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "천천히 걸어가자. 길을 잘 모르니까";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "가긴 어딜가 여기서 살자";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);

        }
        public void ManualCar()
        {
            _game._negativePoint++;
            _game.Text = "어? 수동차량이네 나는 2종보통인데..여기 저기 박으면서 베이스캠프 도착 했더니 몸도 좀 아프고 몇가지 농기구와 씨앗들이 사라졌다.";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "베이스 캠프 복귀 완료.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
        public void Radiation()
        {
            _game.Text = "오래된 우주선이라서 그런가 기분이 이상하네. 방사능 피폭으로 사망";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "처음으로 돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
        public void Comeback()
        {
            _game._positivePoint++;
            _game.Text = "후.. 무사히 베이스 캠프로 돌아왔다";
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "베이스 캠프 복귀 완료.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }
    }
}
