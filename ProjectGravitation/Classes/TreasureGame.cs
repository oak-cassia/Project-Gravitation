﻿using ProjectGravitation.Controlls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ProjectGravitation.Classes
{
    public class TreasureGame
    {
        Game _game;
        int[] location= new int[2];
        int _x, _y; //보물 위치
        int _xDecoy, _yDecoy;// 가짜 신호
        int _radiationLevel=0;
        int _maxRadiation;
        int _eventOne;
        int n;//맵 크기
        List<List<int>> matrixA= new List<List<int>>();//보물 위치는 1 나머지 0
        public TreasureGame(Game game ,int level)
        {

            _game = game;
            _eventOne = 0;
            n = 5 + level * 2;
            _maxRadiation = n;
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
            //각 방마다 이벤트 발생을 시켜야 겠음
            



            // 신호기 확인 함수 및 페이지 버튼을 따로 만드는게 좋을 듯
            //체력이 낮아진다거나 가짜 신호를 뱉는 다거나 하는 것 생성
            if (matrixA[location[0]][location[1]] == 1)
            {
                GameClaer();
                return;
            }
            else if (matrixA[location[0]][location[1]] == 2)
            {
                _game.Text = "이런 가짜였다!!";
                matrixA[location[0]][location[1]] = 0;
                _xDecoy = 99;
                _yDecoy = 99;
            }
            else
            {
                GetEvent();
                //if 문으로 방사능 최대치 시 시작화면
                if(_maxRadiation<=_radiationLevel)
                {
                    _game.Text = "방사능 수치가 가득 차 위험하다 돌아가자";
                    _game.panel.Children.Clear();
                    MyButton button1 = new MyButton();
                    button1.Content = "베이스 캠프로 돌아가기";
                    button1.Command = _game._gameCommand;
                    button1.CommandParameter = button1;
                    _game.panel.Children.Add(button1);
                    return;
                }
                
            }

            // 버튼 조정 각 끄트머리 만났을 때 버튼 삭제
            AdjustPointButton();

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

        void CalcDis()
        {
            int x = location[0] - _x;
            int y = location[1] - _y;
            int xDecoy = location[0] - _xDecoy;
            int yDecoy = location[1] - _yDecoy;

            int locatoin_treasure= Math.Abs(x) + Math.Abs(y);
            int locatoin_Decoy= Math.Abs(xDecoy) + Math.Abs(yDecoy);
           
            
            switch (Math.Min(locatoin_treasure, locatoin_Decoy))
            {
                case 1:
                    _game.Text += "\n뚜 뚜 뚜 뚜 뚜";
                    break;
                case 2:
                    _game.Text += "\n뚜.. 뚜.. 뚜.. 뚜.. 뚜..";
                    break;
                case 3:
                    _game.Text += "\n뚜... 뚜... 뚜... 뚜... 뚜...";
                    break;
                default:
                    _game.Text += "\n하지만 신호가 잡히지 않는다.";
                    break;

            }




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


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (matrixA[i][j] == 1 || matrixA[i][j] == 2)
                    continue;
                    
                    matrixA[i][j]= random.Next(5)+3;
                }
            }

        }

        void GameClaer()
        {
            _game._sectorOneLevel++;

           if(_game._sectorOneLevel==4)// 3단계 완료 시 진행
            {
                _game.Text = "앞에 무언가 보인다. 가까이 다가가자 분간할 수 있다. 나무다.내 머리 쯤 오는 높이에 얼굴이 있다. 아니 얼굴이 있는 것 처럼 보인다.";
                _game._gameCommand.SectorOneEnd();
                return;
            }

            _game._gameCommand.TreasuerGAmeClear();
            
        }

        void AdjustPointButton()
        {
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
            {
                button2.Content = "서쪽 끝 입니다.";
                button2.Focusable = false;
            }
            if (location[0] == n - 1)
            {
                button1.Content = "동쪽 끝 입니다.";
                button1.Focusable = false;
            }

            if (location[1] == 0)
            {
                button3.Content = "남쪽 끝 입니다.";
                button3.Focusable = false;
            }
            if (location[1] == n - 1)
            {
                button4.Content = "북쪽 끝 입니다.";
                button4.Focusable = false;
            }

        }

        void GetEvent()
        {

            switch (matrixA[location[0]][location[1]])
            {
                case 3:
                    _game.Text = "윽... 방사능에 오염된 지역이다. 방사능 수치가 올랐다.\n신호기가 켜졌다.";
                    CalcDis();
                    _radiationLevel++;
                    break;
                case 4:
                    if ( _game._sectorOneLevel == 1)
                    {
                        if (_eventOne == 0)
                        {
                            _game.Text = "땅에 무언가 묻혀 있다.";
                            _eventOne++;
                        }
                        else if (_eventOne == 1)
                        {
                            _game.Text = "여기도 무언가 묻혀 있다. 만져보고 싶은 충동이 생긴다.";
                            _eventOne++;
                        }
                        else if (_eventOne == 2)
                        {
                            _game.Text = "땅에 기다란 구멍이 뚫려있다.";
                        }
                        else
                            _game.Text="신호가 잡히지 않는다.";
                    }

                    if (_game._sectorOneLevel == 2)
                    {
                        if (_eventOne == 0)
                        {
                            _game.Text = "표면이 울퉁불퉁 한게 나무 뿌리 같다.";
                            _eventOne++;
                        }
                        else if (_eventOne == 1)
                        {
                            _game.Text = "땅 밑에 무언가 움직이는 것 같다.";
                            _eventOne++;
                        }
                        else if (_eventOne == 2)
                        {
                            _game.Text = "나도 모르는 사이 뿌리를 붙잡고 있었다.";
                            _eventOne++;
                        }
                        else
                            _game.Text = "신호가 잡히지 않는다.";
                    }

                    if (_game._sectorOneLevel == 3)
                    {
                        if (_eventOne == 0)
                        {
                            _game.Text = "무언가 다리를 스치고 갔다.";
                            _eventOne++;
                        }
                        else if (_eventOne == 1)
                        {
                            _game.Text = "흐느끼는 소리가 들린다.";
                            _eventOne++;
                        }
                        else if (_eventOne == 2)
                        {
                            _game.Text = "웃는 소리가 들린다.";
                            _eventOne++;
                        } 
                        else
                            _game.Text = "신호가 잡히지 않는다.";
                    }

                    matrixA[location[0]][location[1]]=5;
                    break;
                case 5:
                    _game.Text = "별 다른 일은 없다.";
                    break;
                case 6:
                    _game.Text = "신호기 전원이 들어왔다!";
                    CalcDis();// 신호생성
                    break;
                case 7:
                    _game.Text = "신호기가 작동한다!";
                    CalcDis();// 신호생성
                    break;
            }
        }
    }
}
