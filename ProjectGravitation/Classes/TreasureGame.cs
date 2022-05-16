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
        List<List<int>> matrixA= new List<List<int>>();//보물 위치는 1 나머지 0
        public TreasureGame(Game game ,int level)
        {
            _game = game;
            int n = 3 + level * 2;
            for(int i=0;i<n; i++)
            {
                List<int> temp = new List<int>();
                for(int j=0;j<n;j++)
                {
                    temp.Add(0);

                }
                matrixA.Add(temp);
            }
            Random random = new Random((int)DateTime.Now.Ticks);
            Random random1 = new Random((int)DateTime.Now.Ticks);
            int x, y;
            x = random.Next(2)*(n-1);
            y = random1.Next(2)* (n - 1);
            matrixA[x][y] =1;
            location[0] = n / 2;
            location[1] = n / 2;
        }

        public void Move(Button clickedBtn)
        {
            StackPanel panel = clickedBtn.Parent as StackPanel;
            Button tempBtn= new MyButton();
            panel.Children.Add(tempBtn);


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
            if(matrixA[location[0]][location[1]]==1)
            {
                
                
                _game._gameCommand.TreasuerGAmeClear(tempBtn);
                return;

            }
            // 각 끄트머리 만났을 때 함수 제작 및 버튼 생성
            panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "동쪽으로 이동";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "서쪽으로 이동";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
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

            if (location[0] == 0)
                panel.Children.Remove(button2);
            if (location[0] == 4)
                panel.Children.Remove(button1);
            if (location[1] == 0)
                panel.Children.Remove(button3);
            if (location[1] == 4)
                panel.Children.Remove(button4);




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

    }
}
