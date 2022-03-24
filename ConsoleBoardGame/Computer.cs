using System;
namespace ConsoleBoardGame
{
    public class Computer : Player
    {
        private ConnectFourReq requirements = ConnectFourReq.getRequirements();

        public Computer()
        {
        }

        public Computer(string piece, string name)
        {
            Piece = piece;
            Name = name;
        }

        public override int MakeMove(string[] positions)
        {
            return requirements.CalculateMoves(Piece, positions);

        }
    }
}
