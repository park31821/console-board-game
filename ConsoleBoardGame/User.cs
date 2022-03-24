using System;
namespace ConsoleBoardGame
{
    public class User : Player
    {
        public User()
        {
        }

        public User(string piece, string name)
        {
            Piece = piece;
            Name = name;
        }


        public override int MakeMove(string[] args)
        {
            int position;
            bool success;

            Console.Write($"{Name}, please enter a position (number) to place your piece or other commands from above: ");
            success = int.TryParse(Console.ReadLine(), out position);
            Console.WriteLine("");

            while(!success)
            {
                Console.Write("Invalid input! Please enter a position (number) or other commands from above: ");
                success = int.TryParse(Console.ReadLine(), out position);
                Console.WriteLine("");
            }

            return position;
            
        }

    }
}
