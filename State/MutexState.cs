using System;
using System.Threading;
using LabOne.Interfaces;

namespace LabOne.State
{
    public class MutexState : IProgramState
    {
        public Mutex mutexObj = new Mutex();
        public int x=0;
        
        public void ShowInfo(MainProgram program)
        {
            Console.WriteLine("Write number of threads");
            WaitInput(program);
        }

        public void WaitInput(MainProgram program)
        {
            if (Int32.TryParse(Console.ReadLine(), out var result))
            {
                MutexWork(result);
            }
        }


        private void MutexWork(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Thread {i}";
                myThread.Start();
            }
        }
        
        private void Count()
        {
            mutexObj.WaitOne();
            x = 1;
            Console.WriteLine($"Mutex was taken by {Thread.CurrentThread.Name}");
            for (int i = 1; i < 9; i++)
            {
                //Console.WriteLine($"{Thread.CurrentThread.Name} increment value on : {x}");
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
            Console.WriteLine($"Mutex was released by {Thread.CurrentThread.Name}");
        }
    }
}