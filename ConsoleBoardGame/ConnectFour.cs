using System;
namespace ConsoleBoardGame
{
    public class ConnectFour : Game
    {
        private Requirements requirements = ConnectFourReq.getRequirements();

        public ConnectFour()
        {
            Board = new Board(6, 7);
            GameName = "Connect Four";
            BoardLength = Board.Positions.Length;
        }

        public override void UpdateBoard(string piece, int index)
        {
            Console.Clear();
            Board.Positions[index-1] = piece;
            Board.InitiateBoard();
        }

        public override void SetDifficulty()
        {
            requirements.Difficulty = uI.SelectDifficulty();
        }


        public override void SetMode()
        {
            if (mode == 0)
            {
                mode = uI.SelectMode();
            }

            if (mode == 1)
            {
                SetDifficulty();
                players[0] = new User("<-O->", "Player 1");
                players[1] = new Computer("<-X->", "Player 2");
            }
            else
            {
                players[0] = new User("<-O->", "Player 1");
                players[1] = new User("<-X->", "Player 2");
            }
        }

        public override void PlayerDetails()
        {
            foreach(Player player in players)
            {
                player.ShowDetail();
            }
        }
        public override bool GameOver()
        {
            return requirements.CheckWinner(Board.Positions);
        }

        public override bool IsValid(int index)
        {
            return requirements.InputValidator(index, Board.Positions);
        }

        public override void Winner(string winner)
        {
            Console.WriteLine($"Congratulations! {winner} is the winner!");
        }

        public override void OpenHelp()
        {
            requirements.DisplayHelp();
        }

        public override void DisplayCommands()
        {
            requirements.DisplayCommands();
        }
    }
}
