# Project-Gravitation

기존 것 갈아 엎었습니다.


### 추가 방식
- 자기 구역의 게임 클래스를 새로 만들면 될 것 같습니다. 예) GameOne
- Game 클래스에 해당 객체 필드로 갖게 하면 됩니다.
  - 로직을 GameOne 클래스에서 진행
- 데이터바인딩을 해두었기 때문에 Game객체의 _text 수정하면 xaml에 반영됩니다.  
- GameCommand라는 커맨드를 만들었습니다. 
- 버튼은 MyButton으로 만드시면 됩니다. 기본값 수정하는 것 보다 이게 구현이 쉬워서 이렇게 했습니다.
  - 버튼 생성시 컨텐트, 커맨드, 커맨드 파라미터 지정하시면 됩니다.
  - ```c#   
            MyButton  button1 = new MyButton();
            button1.Content = "1지역";
            button1.Command=_game._gameCommand;
            button1.CommandParameter = button1;
            aa.Children.Add(button1);
- 필요시 게임을 진행 하고 끝나면 Game 객체의 레벨 값 수정해야 합니다.
- 빠진 부분이나 설명이 필요한 부분 있으면 카톡으로 알려주세용
