using System;
using System.Threading;
using LabOne.Interfaces;

namespace LabOne.State
{
    public class PullThreadState : IProgramState
    {
        public void ShowInfo(MainProgram program)
        {
            int nWorkerThreads;
            int nCompletionThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionThreads);
            Console.WriteLine("Max Count: " + nWorkerThreads
                                                                  + "\n Available: " + nCompletionThreads);
            for (int i = 0; i < 5; i++)
                ThreadPool.QueueUserWorkItem(JobForAThread);
            Thread.Sleep(3000);
            
            Console.ReadLine();
        }

        public void WaitInput(MainProgram program)
        {
            throw new System.NotImplementedException();
        }
        
        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Loop {0}, Worked from pool {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }
    }
}