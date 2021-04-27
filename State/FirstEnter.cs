using System;
using System.Threading;
using LabOne.Interfaces;
using static System.Int32;

namespace LabOne.State
{
    public class FirstEnter : IProgramState
    {
        public void ShowInfo(MainProgram program)
        {
            Console.WriteLine("Hi write which mode do you like to try");
            Console.WriteLine("1 : Mutex");
            Console.WriteLine("2 : Semafor");
            Console.WriteLine("3 : Atomic");
            Console.WriteLine("4 : Pull Thread");
            
            WaitInput(program);
        }

        public void WaitInput(MainProgram program)
        {
            TryParse(Console.ReadLine(), out var result);
            var programState = HandleInput(result, program);
            if (programState != null)
            {
                program.State = programState;
                program.State.ShowInfo(program);
            }
        }

        private IProgramState HandleInput(int result, MainProgram program)
        {
            switch (result)
            {
                case 1:
                    Console.WriteLine("You've choosed Mutex");
                    return new MutexState();
                case 2:
                    Console.WriteLine("You've choosed Semafor");
                    return new SemaforState();
                case 3:
                    Console.WriteLine("You've choosed Atomic");
                    return new AtomicState();
                case 4: 
                    Console.WriteLine("You've choosed Pull Thread");
                    return new PullThreadState();
                default:
                    Console.WriteLine("Don't know that command try something else");
                    Thread.Sleep(100);
                    Console.Clear();
                    ShowInfo(program);
                    return null;
            }
        }
    }
}