using ProjectGravitation.Controlls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectGravitation.Classes
{
    public class TreasureGame
    {
        Game _game;
        int[] location= new int[2];
        int _x, _y; //보물 위치
        int _xDecoy, _yDecoy;// 가짜 신호

        int n;//맵 크기
        List<List<int>> matrixA= new List<List<int>>();//보물 위치는 1 나머지 0
        public TreasureGame(Game game ,int level)
        {
            _game = game;
            n = 5 + level * 2;
            for(int i=0;i<n; i++)
            {
                List<int> temp = new List<int>();
                for(int j=0;j<n;j++)
                {
                    temp.Add(0);

                }
                matrixA.Add(temp);
            }

            MakeTreasure();
        
        }

        public void Move(Button clickedBtn)
        {
            
            if (clickedBtn.Content.ToString()=="동쪽으로 이동")
            {
                MoveE();
            }
            if (clickedBtn.Content.ToString() == "서쪽으로 이동")
            {
                MoveW();
            }
            if (clickedBtn.Content.ToString() == "남쪽으로 이동")
            {
                MoveS();
            }
            if (clickedBtn.Content.ToString() == "북쪽으로 이동")
            {
                MoveN();
            }


            //체력이 낮아진다거나 가짜 신호를 뱉는 다거나 하는 것 생성
            if (matrixA[location[0]][location[1]] == 1)
            {
                _game._gameCommand.TreasuerGAmeClear();
                return;
            }
            else if (matrixA[location[0]][location[1]] == 2)
            {
                _game.Text = "이런 가짜였습니다!!";
                matrixA[location[0]][location[1]] = 0;
                _xDecoy = 99;
                _yDecoy = 99;
            }
            else
            {
                switch (CalcDis())
                {
                    case 1:
                        _game.Text = "뚜 뚜 뚜 뚜 뚜";
                        break;
                    case 2:
                        _game.Text = "뚜.. 뚜.. 뚜.. 뚜.. 뚜..";
                        break;
                    case 3:
                        _game.Text = "뚜... 뚜... 뚜... 뚜... 뚜...";
                        break;
                    default:
                        _game.Text = "신호가 잡히지 않는다.";
                        break;

                }
            }



            // 각 끄트머리 만났을 때 버튼 삭제
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "동쪽으로 이동";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "서쪽으로 이동";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "남쪽으로 이동";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);

            MyButton button4 = new MyButton();
            button4.Content = "북쪽으로 이동";
            button4.Command = _game._gameCommand;
            button4.CommandParameter = button4;
            _game.panel.Children.Add(button4);

            if (location[0] == 0)
                _game.panel.Children.Remove(button2);
            if (location[0] == n-1)
                _game.panel.Children.Remove(button1);
            if (location[1] == 0)
                _game.panel.Children.Remove(button3);
            if (location[1] == n-1)
                _game.panel.Children.Remove(button4);

           


        }
        public void MoveN()
        {
            location[1]++;
        }
         public void MoveS()
        {
            location[1]--;
        }
         public void MoveW()
        {
            location[0]--;
        }
         public void MoveE()
        {
            location[0]++;
        }

        int CalcDis()
        {
            int x = location[0] - _x;
            int y = location[1] - _y;
            int xDecoy = location[0] - _xDecoy;
            int yDecoy = location[1] - _yDecoy;

            int locatoin_treasure= Math.Abs(x) + Math.Abs(y);
            int locatoin_Decoy= Math.Abs(xDecoy) + Math.Abs(yDecoy);
           
            return Math.Min(locatoin_treasure, locatoin_Decoy);
        }

        void MakeTreasure()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            Random random1 = new Random((int)DateTime.Now.Ticks);
            int temp_x = random.Next(4);
            int temp_y = random1.Next(4);
            switch (temp_x)
            {
                case 0: _x = 0; _xDecoy = n - 1; break;
                case 1: _x = 1; _xDecoy = n - 2; break;
                case 2: _x = n - 1; _xDecoy = 0; break;
                case 3: _x = n - 2; _xDecoy = 1; break;

            }

            switch (temp_x)
            {
                case 0: _y = 0; _yDecoy = n - 1; break;
                case 1: _y = 1; _yDecoy = n - 2; break;
                case 2: _y = n - 1; _yDecoy = 0; break;
                case 3: _y = n - 2; _yDecoy = 1; break;

            }





            matrixA[_x][_y] = 1;
            matrixA[_xDecoy][_yDecoy] = 2;
            location[0] = n / 2;
            location[1] = n / 2;
        }

    }
}
