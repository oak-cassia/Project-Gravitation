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
        /*2지역*/
        public int End_Second_sector = 0; // 2지역 탐사 진행 유무
        public int Quiz_Level_Save = 0;
        /*2지역*/


        Game _game;
        bool _firstText = true;

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
            if (clickedBtn.Content.ToString() == "동쪽으로 이동" || clickedBtn.Content.ToString() == "서쪽으로 이동" || clickedBtn.Content.ToString() == "남쪽으로 이동" || clickedBtn.Content.ToString() == "북쪽으로 이동")
                MoveTreasuerGame(clickedBtn);
            if (clickedBtn.Content.ToString() == "베이스 캠프로 돌아가기")
                MainStart(clickedBtn);
            if (clickedBtn.Content.ToString() == "얼굴에 입을 맞춘다")
            {
                _game._positivePoint += 1; /* 수정 필요*/
                MainStart(clickedBtn);
            }
            if (clickedBtn.Content.ToString() == "나무 가지를 꺾는다")
            {
                _game._negativePoint += 1;
                MainStart(clickedBtn);
            }
            if (clickedBtn.Content.ToString() == "헛기침을 낸다." || clickedBtn.Content.ToString() == "가만히 있는다.")
            {
                EndingN2(clickedBtn);
            }
            if (clickedBtn.Content.ToString() == "...")
            {
                EndingN3();
            }
            if (clickedBtn.Content.ToString() == "눈이 감긴다."|| clickedBtn.Content.ToString() == "우주복을 입은 사람이 나온다.")
            {
                EndingN4();
            }
            if (clickedBtn.Content.ToString() == "종료")
            {
                System.Environment.Exit(0);
            }
            if (clickedBtn.Content.ToString() == "가까워지는 우주선을 쳐다본다." || clickedBtn.Content.ToString()== "들어가 잠이나 잔다.")
            {
                EndingP2(clickedBtn);
            }
            if(clickedBtn.Content.ToString()== "밖으로 나간다.")
            {
                EndingP3();
            }

            /*2지역*/
            TextBox txtbox = parameter as TextBox;


            if (clickedBtn.Content.ToString() == "2지역")
            {
                if ((_game._negativePoint + _game._positivePoint) >= 3)
                {
                    //호출 엔딩
                    if (_game._negativePoint > _game._positivePoint)
                    {
                        EndingN();
                    }
                    else
                    {
                        EndingP();
                    }
                    return;
                }
                if (End_Second_sector != 0)
                {
                    _game._alGame.Already_End_Second_sector(clickedBtn);

                }
                else
                {
                    //Alien_Community(clickedBtn);
                    if (Quiz_Level_Save == 0)
                    {
                        Alien_Community(clickedBtn);
                    }
                    else if (Quiz_Level_Save == 1)
                    {
                        if (_game.Angry != 0) { _game._alGame.Angry_4(clickedBtn); }
                        else if (_game.Friendship != 0) { _game._alGame.FriendShip_4(clickedBtn); }
                        else if (_game.Love != 0) { _game._alGame.Love_4(clickedBtn); }
                    }
                    else if (Quiz_Level_Save == 2)
                    {
                        if (_game.Angry != 0) { _game._alGame.Angry_5(clickedBtn); }
                        else if (_game.Friendship != 0) { _game._alGame.FriendShip_5(clickedBtn); }
                        else if (_game.Love != 0) { _game._alGame.Love_5(clickedBtn); }
                    }
                    else if (Quiz_Level_Save == 3)
                    {
                        if (_game.Angry != 0) { _game._alGame.Angry_6(clickedBtn); }
                        else if (_game.Friendship != 0) { _game._alGame.FriendShip_6(clickedBtn); }
                        else if (_game.Love != 0) { _game._alGame.Love_6(clickedBtn); }
                    }
                }
            }
            if (clickedBtn.Content.ToString() == "소리가 나는 방향으로 이동")
                MoveAlienGame(clickedBtn);
            if (clickedBtn.Content.ToString() == "돌아간다.")
                MainStart(clickedBtn);

            // 2지역 시작
            if (clickedBtn.Content.ToString() == "가까이 다가간다.")
            {
                _game._alGame.Move_2(clickedBtn);
            }

            // 성향 결정
            if (clickedBtn.Content.ToString() == "알아서 뭐하게?")
            {
                _game._alGame.Move_2_1(clickedBtn);
                _game.Angry = 1;
                _game.Friendship = 0;
                _game.Love = 0;
            }
            if (clickedBtn.Content.ToString() == "나는 우주 탐사원이야.")
            {
                _game._alGame.Move_2_2(clickedBtn);
                _game.Angry = 0;
                _game.Friendship = 1;
                _game.Love = 0;
            }
            if (clickedBtn.Content.ToString() == "어? 예쁘다.")
            {
                _game._alGame.Move_2_3(clickedBtn);
                _game.Angry = 0;
                _game.Friendship = 0;
                _game.Love = 1;
            }

            //Angry
            if (clickedBtn.Content.ToString() == "너는 뭐하는 놈이냐?")
            {
                _game._alGame.Angry_1(clickedBtn);
            }
            //Angry_2
            if (clickedBtn.Content.ToString() == "니 알바 아니잖아." || clickedBtn.Content.ToString() == "여길 조사하러 왔다.")
            {
                _game._alGame.Angry_2(clickedBtn);
                if (clickedBtn.Content.ToString() == "니 알바 아니잖아.") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }
            if (clickedBtn.Content.ToString() == "어떡하자는 건데?" || clickedBtn.Content.ToString() == "뭐 싸우자고?")
            {
                _game._alGame.Angry_3(clickedBtn);
                if (clickedBtn.Content.ToString() == "뭐 싸우자고?") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }

            //Angry_3
            if (clickedBtn.Content.ToString() == "상대를 잘못 골랐어 너, 덤벼." || clickedBtn.Content.ToString() == "니 까짓게? 덤벼")
            {
                _game._alGame.Quiz_1(clickedBtn);
                if (clickedBtn.Content.ToString() == "니 까짓게? 덤벼") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }

            //Angry_&_Quiz (Angry_4,5)
            if (clickedBtn.Content.ToString() == "너무 쉬운데?" || clickedBtn.Content.ToString() == "이따위 수준으로 \n해보자고 한거냐?")
            {
                _game._alGame.Quiz_2(clickedBtn);
                if (clickedBtn.Content.ToString() == "이따위 수준으로 \n해보자고 한거냐?") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }
            if (clickedBtn.Content.ToString() == "그래.. 마지막이라도 잘 내봐..." || clickedBtn.Content.ToString() == "너무 쉽죠? 간단하죠?\n 아무것도 못하죠?")
            {
                _game._alGame.Quiz_3(clickedBtn);
                if (clickedBtn.Content.ToString() == "너무 쉽죠? 간단하죠?\n 아무것도 못하죠?") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }
            //Angry_6
            if (clickedBtn.Content.ToString() == "우리 인류가 \n이 행성에서 살게 해줘." || clickedBtn.Content.ToString() == "나와 같은 우리 인류가 \n이 행성에서 살아갈 수 있을까?")
            {
                _game._alGame.Angry_7(clickedBtn);
                if (clickedBtn.Content.ToString() == "우리 인류가 \n이 행성에서 살게 해줘.") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }
            //Angry_7
            if (clickedBtn.Content.ToString() == "빠르게 다녀와." || clickedBtn.Content.ToString() == "기대할게.")
            {
                _game._alGame.Angry_8(clickedBtn);
                if (clickedBtn.Content.ToString() == "빠르게 다녀와.") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }
            //Angry_8
            if (clickedBtn.Content.ToString() == "다행이군." || clickedBtn.Content.ToString() == "그래? 고맙군.")
            {
                _game._alGame.Angry_9(clickedBtn);
                if (clickedBtn.Content.ToString() == "그래? 고맙군.") _game._alGame.AngryPlus();
                else _game._alGame.AngryMinus();
            }
            //Angry_9
            if (clickedBtn.Content.ToString() == "알겠다.")
            {
                _game._alGame.End_Out(clickedBtn);
                End_Second_sector += 1;
                _game._alGame.Alien();//positive&negativePoint
            }


            //FriendShip
            if (clickedBtn.Content.ToString() == "그렇구나. 나에게 이곳을 \n소개 시켜줄 수 있겠니?")
            {
                _game._alGame.FriendShip_1(clickedBtn);
            }
            //FreindShip_2
            if (clickedBtn.Content.ToString() == "나는 지구에서 왔어.")
            {
                _game._alGame.FriendShip_2(clickedBtn);
                _game._alGame.FriendshipPlus();
            }
            if (clickedBtn.Content.ToString() == "내가 살던 행성이야. 지구를 \n구하기 위해서 이곳으로 왔어.")
            {
                _game._alGame.FriendShip_3(clickedBtn);
                _game._alGame.FriendshipPlus();
            }
            //FriendShip_Quiz
            if (clickedBtn.Content.ToString() == "수수께끼? 좋아. 한 번 해 보자." || clickedBtn.Content.ToString() == "수수께끼? 쉽겠네.")
            {
                _game._alGame.Quiz_1(clickedBtn);
                _game._alGame.FriendshipPlus();
            }
            if (clickedBtn.Content.ToString() == "생각보다 조금 어려웠어." || clickedBtn.Content.ToString() == "생각보다 쉬운걸?")
            {
                _game._alGame.Quiz_2(clickedBtn);
                if (clickedBtn.Content.ToString() == "생각보다 조금 어려웠어.")
                {
                    _game._alGame.FriendshipPlus();
                }
                else { _game._alGame.FriendshipMinus(); }
            }

            if (clickedBtn.Content.ToString() == "So easy man~." || clickedBtn.Content.ToString() == "마지막은 좀 어렵겠지?")
            {
                _game._alGame.Quiz_3(clickedBtn);
                if (clickedBtn.Content.ToString() == "마지막은 좀 어렵겠지?")
                {
                    _game._alGame.FriendshipPlus();
                }
                else { _game._alGame.FriendshipMinus(); }
            }
            //FriendShip_6
            if (clickedBtn.Content.ToString() == "우리 인간들이 \n이 행성에서 살 수 있을까?" || clickedBtn.Content.ToString() == "인류가 이 행성에서 \n살아갈 수 있게 해줘.")
            {
                _game._alGame.FriendShip_7(clickedBtn);
                if (clickedBtn.Content.ToString() == "우리 인간들이 \n이 행성에서 살 수 있을까?")
                {
                    _game._alGame.FriendshipPlus();
                }
                else { _game._alGame.FriendshipMinus(); }
            }
            //FriendShip_7
            if (clickedBtn.Content.ToString() == "응, 잘 부탁해." || clickedBtn.Content.ToString() == "부탁할게. \n우리 인류의 존망이 달려있어.")
            {
                _game._alGame.FriendShip_8(clickedBtn);
                if (clickedBtn.Content.ToString() == "부탁할게. \n우리 인류의 존망이 달려있어.")
                {
                    _game._alGame.FriendshipPlus();
                }
                else { _game._alGame.FriendshipMinus(); }
            }
            //FriendShip_8
            if (clickedBtn.Content.ToString() == "정말? 고마워. 정말 다행이야." || clickedBtn.Content.ToString() == "정말 고마워, 덕분에 큰 문제 \n하나는 해결한 것 같아.")
            {
                _game._alGame.FriendShip_9(clickedBtn);
                if (clickedBtn.Content.ToString() == "정말 고마워, 덕분에 큰 문제 \n하나는 해결한 것 같아.")
                {
                    _game._alGame.FriendshipPlus();
                }
                else { _game._alGame.FriendshipMinus(); }
            }
            //FriendShip_9
            if (clickedBtn.Content.ToString() == "정말 정말 정말 고마워.\n언젠가 꼭 이 은혜를 갚을게." || clickedBtn.Content.ToString() == "아니야 그 정도도 우리에게는 충분해.\n정말 고마워.")
            {
                _game._alGame.End_Out(clickedBtn);
                End_Second_sector += 1;
                _game._alGame.Alien();//positive&negativePoint
            }



            //Love
            if (clickedBtn.Content.ToString() == "너 정말 예쁘구나. 너는 누구니?")
            {
                _game._alGame.Love_1(clickedBtn);
            }
            //Love_1
            if (clickedBtn.Content.ToString() == "저기...?" || clickedBtn.Content.ToString() == "왜 사람 말을 씹어?")
            {
                _game._alGame.Love_2(clickedBtn);

                if (clickedBtn.Content.ToString() == "저기...?") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }

            //Love_2
            if (clickedBtn.Content.ToString() == "경비병? 경비병이 왜 이렇게 예뻐?" || clickedBtn.Content.ToString() == "왕국? 너희 왕국 사람들도 다들 이렇게 예쁘니?")
            {
                _game._alGame.Love_3(clickedBtn);

                if (clickedBtn.Content.ToString() == "경비병? 경비병이 왜 이렇게 예뻐?") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }

            //Love_3
            if (clickedBtn.Content.ToString() == "그래 한번 해보자." || clickedBtn.Content.ToString() == "싫다면?")
            {
                _game._alGame.Quiz_1(clickedBtn);

                if (clickedBtn.Content.ToString() == "그래 한번 해보자.") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }

            if (clickedBtn.Content.ToString() == "간단한걸?" || clickedBtn.Content.ToString() == "예쁜만큼 재밌는 문제였어.")
            {
                _game._alGame.Quiz_2(clickedBtn);

                if (clickedBtn.Content.ToString() == "예쁜만큼 재밌는 문제였어.") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }

            if (clickedBtn.Content.ToString() == "아까보다 쉬웠는데?" || clickedBtn.Content.ToString() == "정말 기발한 문제야!")
            {
                _game._alGame.Quiz_3(clickedBtn);

                if (clickedBtn.Content.ToString() == "정말 기발한 문제야!") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }
            //Love_6
            if (clickedBtn.Content.ToString() == "우리 행성이 위험해.\n이 행성에서 우리 행성의 사람들이\n살게해 줄 수 있을까?" || clickedBtn.Content.ToString() == "인류가 이 행성에서 살 수 있을만한\n터전을 마련해줘.")
            {
                _game._alGame.Love_7(clickedBtn);

                if (clickedBtn.Content.ToString() == "우리 행성이 위험해.\n이 행성에서 우리 행성의 사람들이\n살게해 줄 수 있을까?") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }
            //Love_7
            if (clickedBtn.Content.ToString() == "정말 고마워. 널 만나서 정말 다행이야." || clickedBtn.Content.ToString() == "부탁할게. 너가 없었다면 \n정말 막막했을텐데, 고마워.")
            {
                _game._alGame.Love_8(clickedBtn);

                if (clickedBtn.Content.ToString() == "부탁할게. 너가 없었다면 \n정말 막막했을텐데, 고마워.") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }
            //Love_8
            if (clickedBtn.Content.ToString() == "어떻게 됐어?" || clickedBtn.Content.ToString() == "고마워. 이제 우리는 어떻게 하면 될까?")
            {
                _game._alGame.Love_9(clickedBtn);

                if (clickedBtn.Content.ToString() == "고마워. 이제 우리는 어떻게 하면 될까?") _game._alGame.LovePlus();
                else _game._alGame.LoveMinus();
            }
            //Love_9
            if (clickedBtn.Content.ToString() == "?????????\n(왕의 펜던트를 획득 하셨습니다.)" || clickedBtn.Content.ToString() == "????????")
            {
                _game._alGame.End_Out(clickedBtn);
                End_Second_sector += 1;
                _game._alGame.Alien(); //positive&negativePoint
            }



            //Quiz_1
            if (clickedBtn.Content.ToString() == "1명!" || clickedBtn.Content.ToString() == "2명!" || clickedBtn.Content.ToString() == "3명!" || clickedBtn.Content.ToString() == "4명!")
            {


                if (clickedBtn.Content.ToString() == "2명!")
                {

                    if (_game.Angry != 0) { for (int i = 0; i < 5; i++) { _game._alGame.AngryMinus(); } _game._alGame.Angry_4(clickedBtn); Quiz_Level_Save += 1; }
                    else if (_game.Friendship != 0) { for (int i = 0; i < 5; i++) { _game._alGame.FriendshipPlus(); } _game._alGame.FriendShip_4(clickedBtn); Quiz_Level_Save += 1; }
                    else if (_game.Love != 0) { for (int i = 0; i < 5; i++) { _game._alGame.LovePlus(); } _game._alGame.Love_4(clickedBtn); Quiz_Level_Save += 1; }
                }
                else
                {
                    if (_game.Angry != 0) { for (int i = 0; i < 5; i++) { _game._alGame.AngryPlus(); } }
                    else if (_game.Friendship != 0) { for (int i = 0; i < 5; i++) { _game._alGame.FriendshipMinus(); } }
                    else if (_game.Love != 0) { for (int i = 0; i < 5; i++) { _game._alGame.LoveMinus(); } }
                    _game._alGame.Quiz_Out(clickedBtn);
                }
            }
            //Quiz_2
            if (clickedBtn.Content.ToString() == "영국 사람" || clickedBtn.Content.ToString() == "한국 사람" || clickedBtn.Content.ToString() == "중국 사람" || clickedBtn.Content.ToString() == "일본 사람")
            {


                if (clickedBtn.Content.ToString() == "일본 사람")
                {
                    _game._alGame.Quiz_1(clickedBtn);
                    if (_game.Angry != 0) { for (int i = 0; i < 5; i++) { _game._alGame.AngryMinus(); } _game._alGame.Angry_5(clickedBtn); Quiz_Level_Save += 1; }
                    else if (_game.Friendship != 0) { for (int i = 0; i < 5; i++) { _game._alGame.FriendshipPlus(); } _game._alGame.FriendShip_5(clickedBtn); Quiz_Level_Save += 1; }
                    else if (_game.Love != 0) { for (int i = 0; i < 5; i++) { _game._alGame.LovePlus(); } _game._alGame.Love_5(clickedBtn); Quiz_Level_Save += 1; }
                }
                else
                {
                    if (_game.Angry != 0) { for (int i = 0; i < 5; i++) { _game._alGame.AngryPlus(); } }
                    else if (_game.Friendship != 0) { for (int i = 0; i < 5; i++) { _game._alGame.FriendshipMinus(); } }
                    else if (_game.Love != 0) { for (int i = 0; i < 5; i++) { _game._alGame.LoveMinus(); } }
                    _game._alGame.Quiz_Out(clickedBtn);
                }
            }
            //Quiz_3
            if (clickedBtn.Content.ToString() == "칫솔" || clickedBtn.Content.ToString() == "흥부" || clickedBtn.Content.ToString() == "소비" || clickedBtn.Content.ToString() == "비실")
            {
                if (clickedBtn.Content.ToString() == "칫솔")
                {
                    if (_game.Angry != 0) { for (int i = 0; i < 5; i++) { _game._alGame.AngryMinus(); _game._alGame.Angry_6(clickedBtn); Quiz_Level_Save += 1; } }
                    else if (_game.Friendship != 0) { for (int i = 0; i < 5; i++) { _game._alGame.FriendshipPlus(); _game._alGame.FriendShip_6(clickedBtn); Quiz_Level_Save += 1; } }
                    else if (_game.Love != 0) { for (int i = 0; i < 5; i++) { _game._alGame.LovePlus(); _game._alGame.Love_6(clickedBtn); Quiz_Level_Save += 1; } }
                }
                else
                {
                    if (_game.Angry != 0) { for (int i = 0; i < 5; i++) { _game._alGame.AngryPlus(); } }
                    else if (_game.Friendship != 0) { for (int i = 0; i < 5; i++) { _game._alGame.FriendshipMinus(); } }
                    else if (_game.Love != 0) { for (int i = 0; i < 5; i++) { _game._alGame.LoveMinus(); } }
                    _game._alGame.Quiz_Out(clickedBtn);
                }
            }



            /*2지역*/

            /*3지역*/
            if (clickedBtn.Content.ToString() == "3지역")
            {
                if ((_game._negativePoint + _game._positivePoint) >= 3)
                {
                    //호출 엔딩
                    if (_game._negativePoint > _game._positivePoint)
                    {
                        EndingN();
                    }
                    else
                    {
                        EndingP();
                    }
                    return;
                }
                _game._sgGame.Storm();
            }
            if (clickedBtn.Content.ToString() == "처음으로 돌아간다.")
            {
                MainStart(clickedBtn);
            }
            if (clickedBtn.Content.ToString() == "오른쪽 건물로 간다")
            {
                _game._sgGame.Building();
            }
            if (clickedBtn.Content.ToString() == "왼쪽 벙커로 간다")
            {
                _game._sgGame.Bunker();
            }
            if (clickedBtn.Content.ToString() == "그냥 폭풍을 뚫고 간다")
            {
                _game._sgGame.Stone();
            }
            if (clickedBtn.Content.ToString() == "왼쪽 벙커로 간다")
            {
                _game._sgGame.Bunker();
            }
            if (clickedBtn.Content.ToString() == "바로 우주선을 연다.")
            {
                _game._sgGame.Food();
            }
            if (clickedBtn.Content.ToString() == "우주선 주변을 탐색하자.")
            {
                _game._sgGame.Trap();
            }
            if (clickedBtn.Content.ToString() == "무시하고 갈길 가자")
            {
                _game._sgGame.Pass();
            }
            if (clickedBtn.Content.ToString() == "몰라 배고프니까 일단 먹자.")
            {
                _game._sgGame.Colic();
            }
            if (clickedBtn.Content.ToString() == "신중하게 유통기한을 보고 먹자.")
            {
                _game._sgGame.Hungry();
            }
            if (clickedBtn.Content.ToString() == "흠..우주선을 좀더 둘러볼까?")
            {
                _game._sgGame.Search();
            }
            if (clickedBtn.Content.ToString() == "탐사 로버가 있네 타고 가자.")
            {
                _game._sgGame.ManualCar();
                _game._negativePoint += 1;
            }
            if (clickedBtn.Content.ToString() == "천천히 걸어가자. 길을 잘 모르니까")
            {
                _game._sgGame.Comeback();
                _game._positivePoint += 1;
            }
            if (clickedBtn.Content.ToString() == "가긴 어딜가 여기서 살자")
            {
                _game._sgGame.Radiation();
            }
            if (clickedBtn.Content.ToString() == "베이스 캠프 복귀 완료.")
            {
                MainStart(clickedBtn);
                return;
            }





            Grid grid = _game.panel.Parent as Grid;
            StackPanel buttons = grid.FindName("buttons") as StackPanel;//https://docs.microsoft.com/ko-kr/dotnet/desktop/wpf/advanced/how-to-find-an-element-by-its-name?view=netframeworkdesktop-4.8
            buttons.Focus();
        }


        //3














        public void MainStart(Button clickedBtn)
        {
            if(_firstText)
            {
                _game.Text = "하늘에 웜홀이 생기고 인류는 서서히 영원한 잠에 빠졌다. 원인을 찾기 위해 파견된" +
                    " 당신은 웜홀을 통과해 이 행성에 도착했다. 각 지역을 탐험해 보자. 어느 지역으로 갈까요?";
            }
            else
                _game.Text ="어느 지역으로 갈까요?";
            StackPanel panel = clickedBtn.Parent as StackPanel;//버튼의 부모인 스택패널 buttons에 접근
            panel.Children.Clear();                    //  자식을 지우고  버튼을 추가해주면 됩니다.
            MyButton button1 = new MyButton();
            button1.Content = "1지역";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "2지역";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            panel.Children.Add(button2);

            MyButton button3 = new MyButton();
            button3.Content = "3지역";
            button3.Command = _game._gameCommand;
            button3.CommandParameter = button3;
            panel.Children.Add(button3);
        }
        public void SectorOneStart(Button clickedBtn)
        {

            if ((_game._negativePoint + _game._positivePoint) >= 3)
            {
                //호출 엔딩
                if (_game._negativePoint > _game._positivePoint)
                {
                    EndingN();
                }
                else
                {
                    EndingP();
                }
                return;
            }

            if (_game._sectorOneLevel == 4)
            {
                _game.Text = "\n클리어 했습니다. 어느 지역으로 갈까요?";
                return;
            }
            _game._trGame = new TreasureGame(_game, _game._sectorOneLevel);

            _game.Text = "신호찾기 레벨" + _game._sectorOneLevel + " 시작";
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
            _game.Text = "신호 찾기 " + (_game._sectorOneLevel - 1) + "레벨 클리어!";

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
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

        }


        
        public void EndingN()
        {
            _game.panel.Children.Clear();
            _game.Text = "소리 없이 지평선 끝부터 그림자가 드리웠다." +
                " 순식간에 내가 있는 곳까지 어두워졌다. 심장이 내려 앉았다. 주변엔 이제 아무것도 보이지 않았다.";
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

            _game.Text = _game.Text + "적막이 흘렀다. 나는 손가락 하나 까딱할 수 없었다." +
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
            _game.Text = "불이 켜졌다. 아니 주변이 밝아진 것이 아니었다. 하늘에 무수한 온전한 눈동자와 텅 빈 흰자가 나타났다. " +
                "그 거대한 눈들은 나를 내려봤다. 그리고 모든 것을 집어삼킬 듯한 거대한 입, 그 입을 본 순간 순식간에 졸음이 밀려왔다.";
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

        public void EndingP()
        {
            _game.panel.Children.Clear();
            _game.Text = "시간이 지나 다음 우주선이 연료를 싣고 올 때가 됐다. " +
                "\n 도착시간 1시간 전, 나는 하늘만 쳐다봤다. 하늘에서 뭔가 반짝였다.";
            MyButton button1 = new MyButton();
            button1.Content = "가까워지는 우주선을 쳐다본다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "들어가 잠이나 잔다.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            _game.panel.Children.Add(button2);

        }
        public void EndingP2(Button button)
        {
            string content = button.Content.ToString();
            if (content == "가까워지는 우주선을 쳐다본다")
            {
                _game.Text = "눈이 빨개져라 봤다. 돌아갈 수 있단느 기대감에 심장이 요동쳤다. 우주선의 크기가 점점 커지더니 이내 지면에 닿았다.";
            }
            else
            {
                _game.Text = "잠을 자던 중 어떤 소리에 깨어났다.";
            }

            _game.panel.Children.Clear();

            _game.Text = _game.Text + "통신 장비에서 지직거리는 소리가 났다. ";
            MyButton button1 = new MyButton();
            button1.Content = "밖으로 나간다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);

        }
        public void EndingP3()
        {
            _game.panel.Children.Clear();
            _game.Text = "통신 장비는 아직 먹통이었다. 지직 거리기만 하고 음성이 들리지는 않았다." +
                " 우주선이 지면에 닿았다. 통신을 시도했지만 장비는 아직도 지지직 거리기만 했다. 이내 문이 열렸다. 나는 이제 돌아갈 수 있을까? 문제는 해결됐을까?";
            MyButton button1 = new MyButton();
            button1.Content = "우주복을 입은 사람이 나온다.";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            _game.panel.Children.Add(button1);
        }



        /*2지역*/
        public void Alien_Community(Button clickedBtn)
        {
            _game._alGame = new AlienGame(_game, _game._Alien_Community);

            _game.Text = "어디선가 기분 나쁜 소리가 난다. 소리의 원인을 찾아보자";
            StackPanel panel = clickedBtn.Parent as StackPanel;
            panel.Children.Clear();
            MyButton button1 = new MyButton();
            button1.Content = "소리가 나는 방향으로 이동";
            button1.Command = _game._gameCommand;
            button1.CommandParameter = button1;
            panel.Children.Add(button1);

            MyButton button2 = new MyButton();
            button2.Content = "돌아간다.";
            button2.Command = _game._gameCommand;
            button2.CommandParameter = button2;
            panel.Children.Add(button2);



        }

        public void MoveAlienGame(Button clickedBtn)
        {

            _game._alGame.Move_1(clickedBtn);

        }
        /*2지역*/

    }
}
