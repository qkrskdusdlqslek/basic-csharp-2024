# C# 기본 학습
2024년 IoT개발자과정 C# 리포지토리

## 1일차
- C# 소개
    - MS에서 개발한 차세대 프로그래밍 언어
    - 2000년 최초 발표. 앤더스 하일버그(파스칼, 델파이 개발자)
    - 1995년 JAVA 발표되면서 경쟁하기 위해서 개발
    - 객체지향 언어, C/C++과 JAVA를 참조해서 개발
    - OS플랫폼 독립적, 메모리 관리 쉬움
    - 다양한 분야에서 사용 중
    - 2024년 기준 12버전

- .NET Framework(CLR)
    - Windows OS에 종속적
    - OS 독립적인 새로운 틀을 제작하기 시작(2022년 ~) -> .Net 5.0, 현재 .NET 8.0
    - 2024년 현재 .Net 8.0 
    - C/C++ gcc 컴파일러, Java는 JDK, C#은 .NET 5.0 이상 필요
    - 이제는 신규개발 시 **.NET Framework는 사용하지 말 것!**

- Hello, C#!
    - Visual Studio 시작
    - 프로젝트 : 프로그램 개발 최소단위 그룹
    - **솔루션 : 프로젝트의 묶음**

    ```cs
    namespace hello_world // 소스의 가장 큰 단위 namespace == project
    {
    internal class Program // 접근제한자 class 파일명
        {
        static void Main(string[] args) // 정적 void Main ...
            {
            // System 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
            Console.WriteLine("Hello, World!");
            }
        }
    }   
    ```

- 변수와 상수
    - C++과 동일
    - 모든 C#의 객체는 Object를 조상으로
    - 프로그램 메모리에는 스택(값형식, 정수, 실수 etc..), 힙(참조형식, 클래스, 문자열, 리스트 배열, etc..)
    - 박싱, 언박싱
    ```cs
    int a 20; // 스택에 할당
    object b = a; // 박싱(object 박스에 담는다) -> 힙에 올리는 것

    int c = (int) b; // 언박싱(object를 각 타입으로 변환)
    ```
    - 상수는 const 키워드 사용
    - var는 컴파일러가 자동으로 타입을 지정해주는 변수. 지역변수에만 사용 가능

- 연산자
    - C++과 동일
    - ++, --가 파이썬에는 없음
    - and, or가 C++, C#에서는 &&, || 라는 것

- 흐름 제어
    - c++과 동일
    - if, switch, while, do~while, for, break, continue, goto문 모두 동일
    - **C#에는 foreach가 존재** - python의 for item in [] 과 동일

    ```cs
     int[] arr = { 1, 2, 3, 4, 5 };

    foreach (var item in arr)
    {
        Console.WriteLine($"현재 수 : {item}");
    }
    ```

- 메소드(Method)
    - 함수와 동일. 구조적 프로그래밍에서 함수면, 객체지향에서는 메소드로 부름(파이썬만 예외)
    - **매개변수 참조형식** : C++에서 Pointer로 값을 사용할 때와 동일한 기능, 키워드 ref

    ```cs
    public static void RefSwap(ref int a, ref int b)
    {
        int temp = b;
        b = a;
        a = temp;
    }

    //사용시에도 ref 키워드 사용
    RefSwap(ref x, ref y);
    ```

    - 매개변수 출력형식 : 매개변수를 리턴값으로 사용하도록 대체해주는 방법(과도기적인 방법), 키워드 out

    ```cs
    public static void Divide(int a, int b, out int quotient, out int remainder)
    {//...
    ```
    - 메소드 오버로딩 : 여러타입으로 같은 처리를 하는 메소드를 여러개 만들 때
    - 매개변수 가변길이 : 매개변수 개수를 동적으로 처리할 때

    ```cs
     public static int SUm(params int[] argv)
    {//...
    ```

    - 명명된 매개변수 : 매개변수 사용순서를 변경가능

    ```cs
     public static void PrintProfile(string name, string phone)
    {//...

    PrintProfile(phone: "010-9999-8888", name: "홍길동");
    ```

    - 기본값 매개변수 : 매개변수값 미할당시 기본값으로 지정

    ```cs
    public static void DefaultMethod(int a = 1, int b = 0)
    {//...

    DefaultMethod(10, 8); //10, 8
    DefaultMethod(10); // 10, 0
    DefaultMethod(); // 1, 0
    ```

- 클래스
    - C++의 클래스, 객체와 유사(문법 다소 상이)
    - 생성자는 new로 사용해서 객체 생성
    - 종료자(파괴자)는 C#에서 거의 사용 안함
    - 생성자 오버로딩 -> 파라미터 개수에 따라서 사용가능, 기본적인 메소드 오버로딩하고 기능 동일
    - this키워드 -> C++ this-> 라면 / C# -> C# this. 파이썬의 self와 동일
    - 접근한정자( Access Modifier)
        - public - 모든 곳에서 접근
        - private - 외부에서 접근 불가(내부에서만!)(default)
        - protected - 외부에서 접근 불가(화생클라스), 파생(상속)클래스에서는 사용 가능
        - internal - 같은 어셈블리(네임스페이스)내에서는 public과 동일
        - protected internal, private protected - 난이도 있는 한정자(고급)

    - C#에는 C++과 같은 다중상속 없음 / C++에 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 아예 없앰
        - 다중상속이 필요함을 해결 -> 인터페이스

        ```cs
        class BaseClass {
            // 부모클래스
        }
        class DerivedClass : BaseClass{
            // 자식(파생)클래스
        }
        ```
- 구조체
    - 객체지향이 없었으 때 좀 더 객체지향적인 프로그래밍을 위해서 만들어진 부분(C에서)
    - class이후로 사용 빈도가 완전히 줄어든 구조
    - 구조체는 스택(값 형식), 클래스 힙(참조형식)
    - C#에서는 구조체 안 써도 됨

- 튜플(C# 7.0 이후 반영)
    - 한꺼번에 여러개의 데이터를 리턴하거나 전달할 때 유용
    - 값 할당 후 변경불가

- 인터페이스
    - 클래스 : 객체의 청사진 / 인터페이스 : 클래스의 청사진
    - 인터페이스는 클래스가 어떠한 메소드를 가져야 하는지를 약속하는 것
    - 다중상속의 문제를 단일상속으로도 해결하게 만든 주체
    - 인터페이스는 명명할 때 제일 앞에 I를 적음
    - 인터페이스의 메서드에는 구현을 작성하지 않음
    - 인터페이스는 약속!
    - 클래스는 상속한다 VS 인터페이스는 구현한다
    - 클래스는 상속 시 별다른 문제가 없음 VS 인터페이스는 구현할 때 약속을 지키지 않으면 오류표시
    - 인터페이스에서 약속한 메소드를 구현 안하면 빌드가 안됨!

    ![인터페이스 설명](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs001.png)

- 추상클래스(abstract)
    - Virtual 메소드하고 유사
    - 추상클래스를 단순화 시키면 인터페이스 

- 프로퍼티(뒤에 괄호 없음)
    - 클래스의 멤버변수 변형, 일반 변수와 유사
    - 멤버변수의 접근제한자를 public으로 했을 때의 객체지향적 문제점(코드오염 등..)을 해결하기 위해서
    - GET접근자/SET접근자
    - SET은 값 할당시에 잘못된 데이터가 들어가지 않도록 막아야 함
    - Java에서는 Getter메소드/Setter메소드로 사용

## 2일차
- TIP, C#에서 빌드 시 오류 프로세스 엑세스 오류
    - 빌드하고자는 프로그램이 백그라운드 상에 실행중이기 때문
    - Ctrl + Shift + Esc(작업관리자) 에서 해당 프로세스 작업 끝내기 후
    - 재빌드

- 컬렉션(배열, 리스트, 인덱스)
    - 모든 배열은 System.Array 클래스를 상속한 하위 클래스
    - 기본적인 배열의 사용법, Python 리스트와도 동일
    - 배열 분할 - C# 8.0부터. 파이썬의 배열 슬라이스를 도입
    - 컬렉션 , 파이썬의 리스트, 스택, 큐, 딕셔너리와 동일
        - ArrayList
        - Stack
        - Queue
        - Hashtable(== Dictionary)
    - foreach를 사용할 수 있는 객체로 만들기 - yield

- 일반화(Generic) 프로그래밍
    - 파이썬 : 변수에 제약사항 없음. 
    - 타입의 제약을 해소하고자 만든 기능. ArrayList 등이 해결(단, 박싱(언박싱)등 성능의 문제가 있음) 
    - **하나의 메소드로 여러 타입을 처리해줄 수 있는 프로그래밍 방식**
    - 일반화 컬렉션
        - List<T>
        - Stack<T>, Queue<T>
        - Dictionary<TKey, TValue> 

- 예외처리
    - 소스코드 상 문법적 오류 - 오류(Error)
    - 실행 중 생기는 오류 - 예외(Exception)

    ```cs
    try
    {   // .. 예외가 발생할 것 같은 소스코드
        for (int i = 0; i < 4; i++)
            {
            // 0, 1, 2, 3
            Console.WriteLine($"{array[i]}");
            }
    }
    catch (Exception ex) // 모든 예외클래스의 조상이 Exception이므로  
    {   // 어떤 예외클래스를 써야할지 모르면 무조건 Exception 클래스
        Console.WriteLine(ex.Message);
    }
    finally
    {   // 예외발생 유무에 상관없이 항상 실행
        Console.WriteLine("프로그램 종료!");
    }
    ```

- 대리자와 이벤트
    - 메소드 호출 시 매개변수 전달
    - 대리자 호출 시 함수(메소드) 자체를 전달
    - 이벤트 : 컴퓨터 내에서 발생하는 객체의 사건들
    - 익명 메서드 사용
    - delegate --> event
    - 윈폼개발 --> 이벤트 기반(Event driven) 프로그래밍
    - 

- TIP, C# 주석 중 영역을 지정할 수 있는 주석
    - #region ~ #endregion 영역을 Expend 또는 collapse 가능

    ![region 주석](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs002.png)

## 3일차
- 람다식
    - 익명 메소드를 만드는 방식 중에 하나 - delegate, lambda expression
    - 익명 메소드시 코딩량 줄여줌, 프로퍼티 사용시에도 코딩양이 줄어듬
    - 익명 메소드 사용시 마다 대리자를 선언해야 하기 때문에 
        - Func, Action을 MS에서 미리 만들어둠

- LINQ(Language INtegrated Query) 
    - C#에 통합된 데이터 질의 기능(DB SQL과 거의 동일)
    - group by에 집계함수가 필수가 아닌 것 외에는 SQL과 거의 동일
    - 단, 키워드 사용순서 다른 것을 인지해야 함
    - LINQ만 고집하면 안됨. 기존의 C# 로직을 사용해야 할 경우도 있음.. 

- 리플렉션, 애트리뷰트
    - 리플렉션 object.GetType(); 
    - [Obsolete("다음 버전 사용불가")]

- 파이썬 실행
    - COM 객체 사용(dynamic 형식)
    - IronPython 라이브러리 : Python을 C#에서 사용할 수 있도록 오픈소스 라이브러리
    - NuGet Package : 파이썬 pip와 같은 라이브러리 관리툴
    - 해당 프로젝트에서 종속성, 마우스 오른쪽 버튼 > NuGet Package 관리
        1. 파이썬 엔진, 스코프, 설정경로 객체 생성
        2. 해당 컴퓨터 파이썬 경로들 설정
        3. 실행시킬 파이썬 파일의 경로 지정
        4. 파이썬 실행(scope 연결)
        5. 파이썬 함수를 Func 또는 Action으로 매핑
        6. 매핑시킨 메소드를 다시 실행

- 가비지 컬렉션
    - C, C++은 메모리 사용시 개발자가 직접 메모리 해제 해야 함
    - C#, Java, Python 등의 객체지향 언어는 Garbage Collection(쓰레기 수집기) 기능으로 프로그램이 직접 관리
    - C# 개발자 메모리 관리에 아무것도 할게 없다!!

- 윈폼 UI 개발 + 파일, 스레드
    - 이벤트, 이벤트핸들러 (대리자, 이벤트 연결)
    - 그래픽 사용자 인터페이스를 만드는 방법
        1. Winforms(Windows Forms)
        2. WPF(Windows Presentation Foundation)
    - WYSIWYG(What You See Is What You Get) 방식의 GUI 프로그램 개발

## 4일차
- 윈폼 UI 개발 
    - Winforms로 윈폼 개발 학습
    - 컨트롤 Prefix(거의 영문자 3단어)
        - ComboBox : Cbo-
        - CheckBox : Chk- 
        - RadioButton : Rdo-
        - TextBox : Txt-
        - Button : Btn-
        - TrackBar : Trb-
        - ProgressBar : Prg-
        - TreeView : Trv-
        - ListView : Lsv-
        - PictureBox : Pic-
        - *Dialog : Dlg-
        - RichTextBox : Rtx-

## 5일차
- 윈폼 UI 개발(계속)
    - 스레드 추가
        - 프로세스를 나누어서 동시에 여러가지일 진행
        - 스레드 사용하기 불편
        - C# BackgroundWorker 클래스를 추가(Thread를 사용하기 편하게 만든 클래스)
    
    - 파일 입출력 추가
        - 리치텍스트박스(like MSWord, 한글워드)로 파일저장

        <img src="https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs003.png" width="850">

    - 비동기 작업 앱
        - 가장 트렌드가 되는 작업방법
        - 백그라운드 처리, BackgroundWorker와 유사 
        - async, await 키워드

        ![비동기앱](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs004.png)

## 6일차
- 토이 프로젝트
    - 윈도우 탐색기 앱(컨트롤학습)
        - MyExplorer 프로젝트 생성
        - 아이콘 검색, png 2 ico 구글링 웹사이트
        - 트리뷰, 리스트뷰 기능 추가

        ![중간결과](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs005.png)

        - 미적용 - 컨텍스트메뉴 보기 기능, 더블클릭 프로그램 실행, ...

## 7일차
- 토이 프로젝트
    - 윈도우 탐색기 앱 종료
        - 실행결과

        https://github.com/qkrskdusdlqslek/basic-csharp-2024/assets/158007421/86c8993a-7ef4-41bf-bf3e-1797bcca8a26


    - 도서관리 앱 wiht SQL Server(Base) ModernUI(NuGet패키지)
    ```cs
    // 값형식 변수에 null값을 넣을 수 있도록 만들어준 기능 Nullable. 변수명 뒤에 '?'만 추가할 것!
    int? a = null;
    double? b = null;
    float? c = null;
    ```
    - isMdiContainer : 여러 창 
    - Menustrip : 위에 상단 바 만들기
    - statusStrip : 아래
    - 종속성 > 오른쪽 버튼 누르고 NuGet패키지 > 찾아보기 > MetroFramework > (MetroModernUI 사용) > 패키지 관리자 콘솔(도구에) > Install-Package MetroModernUI
    - Alt + Enter : 매서드 자동 생성
    - ControlBox : 
    - KeyPress : 엔터 누르면 어떻게 되는지 정하는 핸들러
    - passwordchar: 비밀번호 안 나오게 -> ㅁ적고 한자키 눌러서 특수문자 나오게 하고 2번째장에 있는 1번 사용
    - Ctrl+Shift+Esc : 작업 끝내기
    - 보기에 서버탐색기 들어가서 데이터연결 오른쪽버튼 > localhost > sa > mssql_p@ss
    - 쿼리 생성하기(vs2022에서 바로 새쿼리 만들어서 복붙 가능)

        - 로그인 패스워드 암호화 미구현

## 8일차
- 토이 프로젝트
    - 도서관리 앱 
        - 앱 사용자관리 완료

## 9일차
- 토이 프로젝트
    - 기존 만들어진 폼을 복사해서 변경할 시
        - ***.cs에 있는 클래스명, 생성자, Designer.cs에 있는 클래스명*** 3군데 변경
    - 도서관리 앱
        - 공통 클래스..
        - 책장르 관리
        - 책정보 관리 

## 10일차
- 토이 프로젝트
    - 도서회원 관리
    - 대출관리
    - 이 프로그램은..

    ![책대여프로그램](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs006.png)

## 나머지
- Pending
    - 국가교통정보센터 CCTV뷰 앱(OpenAPI, NuGet dll, Network, UI 디자인, 비동기 메서드)
    - IoT Dummy 앱 with SQL Server(IoTm DB)


## 개인 토이프로젝트
- 계산기 (완료)
    - 기능 
        - 사칙연산

    - 배운점 
        - 사칙연산을 위한 코드 구성
        - 디자인 과정에서 일정한 크기의 공간을 만들기 위해서 **tableLayoutPanel**을 사용하면 됨
        - 실행 했을 때 창이 중간에 띄워지는 기능 (**ImageAlign을 MiddleCenter로 설정**)
        - 0으로 나눌 시 "0으로 나눌 수 없습니다"라는 메세지 출력 기능 

    - 사진이나 동영상 올리기

    ![계산기](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs007.png)

  

    https://github.com/qkrskdusdlqslek/basic-csharp-2024/assets/158007421/ff3bba6a-7d25-4a3d-a951-fe00989d8b3f


- 주차관리시스템(DB 작업 해야 함)
    - 기능 
        - 입고,출고 시간 
        - 시간에 따른 비용
        - 비용 정산
        - 차량번호 조회(DB) (해결못함)

    - 특징  
        - 차량이 들어오고 나가는 시간이 프로그램에 입력됨(입고,출고)
        - 1시간에 1,000의 비용이 발생하도록 설정
        - 정산 버튼을 누르면 지불해야 하는 금액이 나오도록 설정

    - 배운점
        - 비용 정산하는 부분이 어려움
        - 금액 나오는 부분에서 소수점까지 나오는 부분 해결
        - 차량번호 조회를 구현하기 위해서는 DB를 만들어 연동시켜야 함
        - 실행 했을 때 창이 중간에 띄워지는 기능 (**ImageAlign을 MiddleCenter로 설정**)


    ![주차관리시스템](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs008.png)

    ![주차관리시스템](https://raw.githubusercontent.com/qkrskdusdlqslek/basic-csharp-2024/main/images/cs009.png)

    - 해결해야 하는 것
        - DB 연동해서 차량번호 조회



- 메모장 프로그램
    - 기능
        - 새로 만들기/ 열기/ 저장/ 끝내기/ 복사하기/ 붙여넣기 기능 구현
        - 복사하기 붙여넣기 기능에서 Ctrl-c, Ctrl-V 사용 가능

    - 배운점
        - **새로 만들기 기능에서 현재 작업 중인 파일이 저장 될 필요**가 있을 수 있기 때문에 MessageBox를 통해서 "변경된 내용을 저장하시겠습니까?"를 확인해야 함
        - SaveFileDialog를 사용해 현재 문서의 내용을 저장한 후 새 문서를 시작하기 위해 FileProcessBeforeClose() 함수 만듬
        - **열기 메뉴**에서도 현재 작업중인 파일을 저장할 필요가 있기 때문에 **새로만들기**에서 사용한 코드를 활용함
        - try ~ catch문 사용
        - Ctrl-c, Ctrl-V 사용 할 수 있는 코드



        https://github.com/qkrskdusdlqslek/basic-csharp-2024/assets/158007421/660f06a4-4672-49be-9963-0456fd7428bc



