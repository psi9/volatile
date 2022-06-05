using System;
using System.Threading;

namespace volatile2
{
    class Program
    {


        public class Example1
        {
            private int flag = 0;
            private int value = 0;
            public void Thread1()
            {
                flag = 1;
                value = 5;
            }

            public void Thread2()
            {
                if (flag == 1)
                    Console.WriteLine("e1 " + value);
                else
                    Console.WriteLine("e1 fail");
            }
        }


        public class Example2
        {
            private int flag = 1;
            private int value = 0;
            public void Thread1()
            {
                value = 5;
                Volatile.Write(ref flag, 1);
            }

            public void Thread2()
            {
                if (Volatile.Read(ref flag) == 1) 
                    Console.WriteLine("e2 " + value);
                else
                    Console.WriteLine("e2 fail");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var e1 = new Example1();
            Thread thread11 = new Thread(new ThreadStart(e1.Thread1));
            Thread thread12 = new Thread(new ThreadStart(e1.Thread2));

            var e2 = new Example2();
            Thread thread21 = new Thread(new ThreadStart(e2.Thread1));
            Thread thread22 = new Thread(new ThreadStart(e2.Thread2));

            thread11.Start();
            thread12.Start();

            thread21.Start();
            thread22.Start();
        }
    }
}
