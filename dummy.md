## 더미프로그램 
    1. Controller 프로세스(Main Process) 및 Room에 접속하는 Client Dummy 프로스세스들
    2. Controller 프로세스는 TestRoom을 만드는 기능을 제공.
        - TestRoom을 만드는 기능
            a. 우선, 방장프로세스를 만든다. 프로세스 생성시, 방의 이름과 제한인원수의 정보도 함께 보낸다. 방장프로세스는 서버에 방을 만들겠다는 명령을 보내고, 방이 성공적으로 만들어지면 Controller프로세스에게 신호를 보낸다. (신호는 IPC를 통해서 할 예정.)

            b. 방장프로세스로부터 방을 만들었다는 신호를 받으면, limits-1 만큼의 클라이언트 프로세스를 만들고, 각 프로세스들은 Ready를 한다. Ready를 성공적으로 하면, Controller 프로세스에게 신호를 보낸다.

            c. Ready 신호를 받은 Controller 프로세스는 Ready Count 정보를 갱신하고, Count정보가 limits-1와 같아지면 ,방장프로세스에게 Start 하라는 신호를 보낸다.

            d. Start 신호를 받은 방장프로세스는 Start 명령을 서버에 보내고 게임을 시작한다.

            e. 해당 TestRoom안에 있는 모든 Client는 서버에게 Dummy Data 송/수신 받는다.