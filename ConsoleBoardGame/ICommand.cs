using System;
namespace ConsoleBoardGame
{
    public interface ICommand
    {
        void Execute();
        void Undo();

    }
}
