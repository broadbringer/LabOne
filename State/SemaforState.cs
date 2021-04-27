using System;
using System.Threading;
using LabOne.Interfaces;

namespace LabOne.State
{
    public class SemaforState : IProgramState
    {
        public void ShowInfo(MainProgram program)
        {
            for (int i = 1; i < 4; i++)
            {
                Reader reader = new Reader(i);
            }
 
            Console.ReadLine();
        }

        public void WaitInput(MainProgram program)
        {
            
        }
    }
    
    public class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(4, 4);
        Thread myThread;
        int count = 4;// счетчик чтения
         
        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Reader {i.ToString()}";
            myThread.Start();
        }
 
        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();
 
                Console.WriteLine($"{Thread.CurrentThread.Name} come into");
 
                Console.WriteLine($"{Thread.CurrentThread.Name} reading");
                Thread.Sleep(1000);
 
                Console.WriteLine($"{Thread.CurrentThread.Name} left");
 
                sem.Release();
 
                count--;
                Thread.Sleep(5000);
            }
        }
    }
}