using System;
using System.Threading;
using LabOne.Interfaces;

namespace LabOne.State
{
    public class AtomicState : IProgramState
    {
        static int x=0;
        static object locker = new object();
        public void ShowInfo(MainProgram program)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "Thread " + i.ToString();
                myThread.Start();
            }
        }

        public void WaitInput(MainProgram program)
        {
            throw new System.NotImplementedException();
        }
        
        public static void Count()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}