using System;
namespace ConsoleBoardGame
{
    public abstract class Requirements
    {

        public int Difficulty { get; set;}

        public abstract bool CheckWinner(string[] positions);

        public abstract int CalculateMoves(string piece, string[] positions);

        public abstract bool InputValidator(int index, string[] positions);

        public abstract void DisplayHelp();

        public abstract void DisplayCommands();
    }


}
