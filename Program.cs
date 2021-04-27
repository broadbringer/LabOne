using LabOne.Interfaces;
using LabOne.State;

namespace LabOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mainProgram = new MainProgram(new FirstEnter());
            mainProgram.ShowInfo();
        }
    }

    public class MainProgram
    {
        public IProgramState State;

        public MainProgram(IProgramState state)
        {
            State = state;
        }

        public void ShowInfo()
        {
            State.ShowInfo(this);
        }

        public void WaitInput()
        {
            
        }
    }
}