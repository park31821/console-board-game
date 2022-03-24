using System;
namespace ConsoleBoardGame
{
    public abstract class Player
    {
        public string Name { get; set; }
        public string Piece { get; set; }

        public abstract int MakeMove(string[] args);
        public virtual void ShowDetail()
        {
            Console.WriteLine($"{Name} is {Piece}.");
        }

    }
}
