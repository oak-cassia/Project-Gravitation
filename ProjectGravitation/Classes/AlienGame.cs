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
    public class AlienGame
    {
        Game _game;


        
        public int Angry = 0;
        public int Love = 0;
        public int Friendship = 0;
        public int Quiz = 0; // 하나 맞추면 +1 , 문제 틀리면 퀴즈를 맞췄던 부분 부터 다시, 첫번째 문제 틀리면 처음부터 다시.

        public AlienGame(Game game, int _Alien_Community)
        {
            _game = game;
            Alien_Community = _Alien_Community;
        }


        public int Alien_Community { get; }

        public void Alien()
        {
            if (_game.Angry != 0)
            {
                if (Angry > 5)
                {
                    _game._negativePoint += 1;
                }
                else
                {
                    _game._positivePoint += 1;
                }
            }
            else if (_game.Love != 0)
            {
                if (Love > 10)
                {
                    _game._positivePoint += 1;
                }
                else
                {
                    _game._negativePoint += 1;
                }
            }
            else if (_game.Friendship != 0)
            {
                if (Friendship > 0)
                {
                    _game._positivePoint += 1;
                }
                else
                {
                    _game._negativePoint += 1;
                }
            }
        }

        public void Move_1(Button clickedBtn)
        {
            _game.Text = "#$%#&*$%&!#$@!~$@#%!@#$%!#$&^$";
            StackPanel panel = clickedBtn.Parent as StackPanel;
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "가까이 다가간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "돌아간다.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);


        }

        public void Move_2(Button clickedBtn)
        {
            _game.Text = "누구냐 넌?";
            StackPanel panel = clickedBtn.Parent as StackPanel;
            _game.panel.Children.Clear();

            MyButton button1 = new MyButton();
            button1.Content = "알아서 뭐하게?"; // Angry + 1;
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "나는 우주 탐사원이야.";  // Freindship + 1;
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "어? 예쁘다.";  // Love + 1;
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);


        }

        public void Move_2_1(Button clickedBtn)
        {
            _game.Text = "뭐?";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "너는 뭐하는 놈이냐?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
            AngryPlus();

        }
        public void Move_2_2(Button clickedBtn)
        {
            _game.Text = "그렇구나. 나는 이곳을 지키는 경비병이야!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "그렇구나. 나에게 이곳을 \n소개 시켜줄 수 있겠니?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
            FriendshipPlus();

        }
        public void Move_2_3(Button clickedBtn)
        {
            _game.Text = "두근..";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "너 정말 예쁘구나. 너는 누구니?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
            LovePlus();

        }
        // Angry
        public void Angry_1(Button clickedBtn)
        {
            _game.Text = "나는 이곳을 지키는 경비병이다! 너는 누구냐 정체를 밝히지 않으면 가만두지 않겠다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "니 알바 아니잖아.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "여길 조사하러 왔다.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);


        }
        public void Angry_2(Button clickedBtn)
        {
            _game.Text = "말이 통하지 않는군!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "어떡하자는 건데?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "뭐 싸우자고?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void Angry_3(Button clickedBtn)
        {
            _game.Text = "우리 행성에서는 수수께끼로 승부를 내어 원하는 것을 얻어내는 문화가 있다. 승부를 내자!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "상대를 잘못 골랐어 너, 덤벼.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "니 까짓게? 덤벼";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void Angry_4(Button clickedBtn)
        {
            _game.Text = "하! 이걸 맞추다니 생각보다 제법이군. 바로 다음 문제를 내겠다!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "너무 쉬운데?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "이따위 수준으로 \n해보자고 한거냐?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Angry_5(Button clickedBtn)
        {
            _game.Text = "젠장! 너무 잘하잖아! 그래도 마지막은 쉽지 않을 걸?";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "그래.. 마지막이라도 잘 내봐...";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "너무 쉽죠? 간단하죠?\n 아무것도 못하죠?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void Angry_6(Button clickedBtn)
        {
            _game.Text = "믿을 수 없군.. 전부 맞춰 버리다니....\n 약속은 약속이니까. 네가 원하는 것은 무엇이지?";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "우리 인류가 \n이 행성에서 살게 해줘.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "나와 같은 우리 인류가 \n이 행성에서 살아갈 수 있을까?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Angry_7(Button clickedBtn)
        {
            _game.Text = "어려운 부탁이군.. 웬만하면 내 선에서 이루어 줄 수 있지만, \n이건 보통 일이 아니야.\n국왕님께 여쭈어 볼테니 \n조금 기다리고 있어.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "빠르게 다녀와.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "기대할게.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Angry_8(Button clickedBtn)
        {
            _game.Text = "오래 기다렸지? 국왕님께 \n여쭈어 보고 왔어. \n국왕님께서 친히 너희 종족의 \n안녕을 살펴주신다고 한다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "다행이군.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "그래? 고맙군.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Angry_9(Button clickedBtn)
        {
            _game.Text = "너희는  sector_A-7 지역에서 \n살면 돼. 그곳에서 기다리고 \n있으면 우리 병사들이 너희들을 \n지원하러 갈거야."; // Angry > 5 이면 외계인의 배신.
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "알겠다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }

        //Friendship
        public void FriendShip_1(Button clickedBtn)
        {
            _game.Text = "이곳은 행성 쿠피탈로카니스라이두. 근처에 우리 왕국이 있어. 다른 행성에서 온 침입자로부터 왕국을 지키기 위해서 \n경비 근무를 서고 있어.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "나는 지구에서 왔어.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
            FriendshipPlus();
        }
        public void FriendShip_2(Button clickedBtn)
        {
            _game.Text = "지구?";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "내가 살던 행성이야. 지구를 \n구하기 위해서 이곳으로 왔어.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
            FriendshipPlus();
        }
        public void FriendShip_3(Button clickedBtn)
        {
            _game.Text = "그렇구나. 너가 원하는 것이 \n있다면 나와 수수께끼를 해서\n정답을 맞춘다면 원하는 것을 \n들어줄게. 어때?";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "수수께끼? 좋아. 한 번 해 보자.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "수수께끼? 쉽겠네.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void FriendShip_4(Button clickedBtn)
        {
            _game.Text = "순식간에 맞추다니! 잘하는걸? 바로 다음문제 갈게.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "생각보다 쉬운걸?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "생각보다 조금 어려웠어.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void FriendShip_5(Button clickedBtn)
        {
            _game.Text = "여기까지는 맞출거라고 예상했어. 마지막 문제야!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "So easy man~.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "마지막은 좀 어렵겠지?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void FriendShip_6(Button clickedBtn)
        {
            _game.Text = "모두 맞추다니, 정말 대단한걸?\n이제 무엇을 원하는지 알려줘. 최대한 노력 해 볼게.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "우리 인간들이 \n이 행성에서 살 수 있을까?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "인류가 이 행성에서 \n살아갈 수 있게 해줘.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void FriendShip_7(Button clickedBtn)
        {
            _game.Text = "역시 쉽지 않은 부탁이군..\n이 문제는 나 혼자서 해결 할 수 없으니, 국왕님께 여쭈어 보고 올게. 기다리고 있어!!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "응, 잘 부탁해.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "부탁할게. \n우리 인류의 존망이 달려있어.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void FriendShip_8(Button clickedBtn)
        {
            _game.Text = "오래 기다렸지? 내가 국왕님께 사정 사정 해서 겨우 허락을 맡아왔어.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "정말? 고마워. 정말 다행이야.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "정말 고마워, 덕분에 큰 문제 \n하나는 해결한 것 같아.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void FriendShip_9(Button clickedBtn)
        {
            string Friendship_End_String;
            string Friendship_End_Reply_String;
            if (Friendship > 15)
            {
                Friendship_End_String = "너희는 sector_A-7로 가서 너희 터전을 잡으면 될 것 같아. \n필요한 물자들은 나에게 와서 말해줘. 우리 왕국에서 최대한 지원해주기로 했으니까.";
                Friendship_End_Reply_String = "정말 정말 정말 고마워.\n언젠가 꼭 이 은혜를 갚을게.";
            }
            else
            {
                Friendship_End_String = "너희는 sector_A-7로 가서 너희 터전을 잡으면 될 것 같아. \n미안하게 됐지만, 땅 이외에는 지원해주기 힘들 것 같아. 여기까지 얻어낸 것도 정말 기적이었어.";
                Friendship_End_Reply_String = "아니야 그 정도도 우리에게는 충분해.\n정말 고마워.";
            }
            _game.Text = Friendship_End_String;
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = Friendship_End_Reply_String;
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }

        //Love
        public void Love_1(Button clickedBtn)
        {
            _game.Text = "두근.....";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "저기...?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "왜 사람 말을 씹어?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void Love_2(Button clickedBtn)
        {
            _game.Text = "크흠흠. 실례했군. 나는 이곳 쿠피탈로카니스라이두의 왕국을 지키는 경비병이야.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "경비병? 경비병이 왜 이렇게 예뻐?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "왕국? 너희 왕국 사람들도 다들 이렇게 예쁘니?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Love_3(Button clickedBtn)
        {
            _game.Text = ".........!! 나,..나는 이곳을 지키는 경비병! 원하는 것이 있다면 내가 내는 문제를 맞춰야 해!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "그래 한번 해보자.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "싫다면?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void Love_4(Button clickedBtn)
        {
            _game.Text = "잘하잖아! 다음 문제를 낼게 꼭 맞춰야 해!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "간단한걸?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "예쁜만큼 재밌는 문제였어.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Love_5(Button clickedBtn)
        {
            _game.Text = "역시 맞출 줄 알았어! 마지막 문제야!!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "아까보다 쉬웠는데?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "정말 기발한 문제야!";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Love_6(Button clickedBtn)
        {
            _game.Text = "모두 정답이야! 너 정말 대단하구나.\n이제 너의 소원을 말해줘. 내가 무슨 일이 있어도 \n어떻게든 이루어 줄게!";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "우리 행성이 위험해.\n이 행성에서 우리 행성의 사람들이\n살게해 줄 수 있을까?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "인류가 이 행성에서 살 수 있을만한\n터전을 마련해줘.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }

        public void Love_7(Button clickedBtn)
        {
            _game.Text = "알겠어. 하지만 나 혼자서 이루어 주기 힘든 부분이야.\n조금만 기다려줘. 국왕님께 여쭈어 보고 해결해 볼게.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "정말 고마워. 널 만나서 정말 다행이야.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "부탁할게. 너가 없었다면 \n정말 막막했을텐데, 고마워.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Love_8(Button clickedBtn)
        {
            _game.Text = "오래 기다렸지?! 국왕님을 만나서 해결하고 왔어.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "어떻게 됐어?";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "고마워. 이제 우리는 어떻게 하면 될까?";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);
        }
        public void Love_9(Button clickedBtn)
        {
            string Love_End_String;
            string Love_End_Reply_String;
            if(Love >= 23)
            {
                Love_End_String = "응, 이제 네가 우리 행성의 국왕이야.\n전 국왕이 너무 반대를 하길래 내가 널 위해서\n죽이고 왕의 증표인 이 펜던트를 가져왔어.\n이제 네가 원하는 대로 하면 돼.";
                Love_End_Reply_String = "?????????\n(왕의 펜던트를 획득 하셨습니다.)";
            }
            else
            {
                Love_End_String = "너희 인류는 sector_A-7에서 살아가면 될거야.\n내가 이곳과 오가며 부족한 것들을 채워줄게.\n대신 나와 결혼 해 줄래?";
                Love_End_Reply_String = "????????";
            }

            _game.Text = Love_End_String;
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = Love_End_Reply_String;
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
        //수수께끼
        public void Quiz_1(Button clickedBtn)
        {
            _game.Text = "첫번째 문제! \n투명 인간은 몇명일까요? \n\n\n 문제를 틀리면 시작 화면으로 돌아갑니다. \n\n문제를 맞추면 저장이 됩니다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "1명!";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "2명!";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "3명!";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);

            MyButton button4 = new MyButton();
            button4.Content = "4명!";
            button4.Command = _game._gameCommand;
            button4.CommandParameter = button4;
            _game.panel.Children.Add(button4);
        }

        public void Quiz_2(Button clickedBtn)
        {
            _game.Text = "두번째 문제! 한국인, 중국인, 영국인, 일본인이 있습니다. \n은근히 고약한 냄새가 나고 있는데, 누구 때문일까요? \n\n\n 문제를 틀리면 시작 화면으로 돌아갑니다.\n\n문제를 맞추면 저장이 됩니다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "영국 사람";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "한국 사람";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);


            MyButton button3 = new MyButton();
            button3.Content = "일본 사람";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);

            MyButton button4 = new MyButton();
            button4.Content = "중국 사람";
            button4.Command = _game._gameCommand;
            button4.CommandParameter = button4;
            _game.panel.Children.Add(button4);

        }

        public void Quiz_3(Button clickedBtn)
        {
            _game.Text = "세번째 문제! \n소나무가 삐지면 뭘까요? \n\n\n 문제를 틀리면 시작 화면으로 돌아갑니다.\n\n문제를 맞추면 저장이 됩니다.";
            _game.panel.Children.Clear();
           
            /*TextBox textBox = new TextBox();
            textBox.FontSize = 40;
            _game.panel.Children.Add(textBox);*/


            MyButton button1 = new MyButton();
            button1.Content = "칫솔";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);


            MyButton button2 = new MyButton();
            button2.Content = "흥부";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);


            MyButton button3 = new MyButton();
            button3.Content = "소비";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            _game.panel.Children.Add(button3);

            MyButton button4 = new MyButton();
            button4.Content = "비실";
            button4.Command = _game._gameCommand;
            button4.CommandParameter = button4;
            _game.panel.Children.Add(button4);

        }

        public void Quiz_Out(Button clickedBtn)
        {
            _game.Text = "틀렸습니다. 메인 화면으로 돌아갑니다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
        //End
        public void End_Out(Button clickedBtn)
        {
            _game.Text = "2지역 탐사가 끝났습니다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
        public void Already_End_Second_sector(Button clickedBtn)
        {
            _game.Text = "이미 2지역 탐사가 완료되었습니다.";
            _game.panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "돌아간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
        



        public void AngryPlus()
        {
            Angry += 1;
        }
        public void AngryMinus()
        {
            Angry -= 1;
        }
        public void LovePlus()
        {
            Love += 1;
        }
        public void LoveMinus()
        {
            Love -= 1;
        }
        public void FriendshipPlus()
        {
            Friendship += 1;
        }
        public void FriendshipMinus()
        {
            Friendship -= 1;
        }
    }
}
