﻿namespace ex10_delegators
{
    delegate int MyDelegate(int a, int b); // 대리자
    delegate int Compare(int a, int b); // 두 값을 비교하는 대리자
    // 어떠한 일이 발생하는지 시스템이 알려주는 것 - 이벤트
    delegate void Notify(string message); // Notify 대리자

    class Notifier
    {
        public Notify EventOccured; // 이벤트 발생(이벤트 메소드 실행)
    }

    class EventListner // 이벤트가 발생하는지 듣고있는 객체
    {
        private string name;
        // 생성자
        public EventListner(string name) { this.name = name; }

        public void SomethingHappened(string message) 
        { 
            Console.WriteLine($"{name}.뭔일이 발생했다! : {message}");
        }
    }

    class Sorting
    {
        // 오름차순 비교
        public int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else return -1;
        }

        // 내림차순 비교
        public int DescendCompare(int a, int b)
        {
            if (a < b)
                return -1;
            else if (a == b)
                return 0;
            else return 1;
        }

        public void BubbleSort(int[] DataSet, Compare comparer)
        {
            int i = 0, j = 0, temp = 0;

            for(i = 0; i < DataSet.Length - 1; i++) 
            { 
                for(j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (comparer(DataSet[j], DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }
    }

    class Calculator // 계산기 클래스
    {
        public int Plus(int a, int b) 
        { 
            return a + b;
        }

        public int Minus(int a, int b) 
        { 
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListner listner1 = new EventListner("리스너1");
            EventListner listner2 = new EventListner("리스너2");
            EventListner listner3 = new EventListner("리스너3");

            // 대리자 체인! notifier의 EventOccured라는 대리자에 리스너 3개에 일어날 수 있는 메소드 연결
            // 일반적인 함수 호출에서 한번에 여러개의 함수 실행이 가능하냐? 불가능!
            notifier.EventOccured += listner1.SomethingHappened;
            notifier.EventOccured += listner2.SomethingHappened;
            notifier.EventOccured += listner3.SomethingHappened;
            notifier.EventOccured("메일을 받았어요!"); // 1, 2, 3 실행
            Console.WriteLine(); 

            notifier.EventOccured -= listner2.SomethingHappened; // 리스너2번의 함수는 실행하지 마
            notifier.EventOccured("파일 다운로드 완료!"); // 1, 3 실행
            Console.WriteLine(); 

            notifier.EventOccured = new Notify(listner2.SomethingHappened) + new Notify(listner3.SomethingHappened);
            notifier.EventOccured("미사일 발사!"); // 2, 3 실행
            Console.WriteLine(); // 윈폼(PyQt등) 이벤트도 이와 유사한 형태로 동작

            #region "버블소트 비교 대리자 사용 코드영역"

            int[] array = { 3, 7, 10, 5, 4, 1, 9, };
            Sorting sorting = new Sorting();    

            Console.WriteLine("오름차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.AscendCompare));

            for(int i = 0;i < array.Length;i++) 
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine();

            Console.WriteLine("내림차순 정렬"); 
            sorting.BubbleSort(array, new Compare(sorting.DescendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine();

            #endregion

            #region "계산기 대리자 코드 영역"

            Calculator calc = new Calculator(); // 객체 생성
            MyDelegate Callback; 

            Callback = new MyDelegate(calc.Plus); // int a, int b가 아닌 Calculator 객체의 Plus() 메소드 전달
            var result = Callback(10, 4); // Callback은 calc.Plus를 실행
            Console.WriteLine(result); // 14
            
            Callback = new MyDelegate(calc.Minus);
            result = Callback(10, 4);
            Console.WriteLine(result); // 6

            #endregion
        }
    }
}
