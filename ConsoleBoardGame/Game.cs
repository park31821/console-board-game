using System;
namespace ConsoleBoardGame
{
    public abstract class Game
    {
        public string GameName { get; set; }
        public int BoardLength { get; set; }
        public int mode = 0;
        protected UI uI = new UI();
        public Player[] players = new Player[2];
        public Board Board { get; set; }
        public bool gameOn = true;

        public abstract void UpdateBoard(string piece, int index);
        public abstract bool IsValid(int index);
        public abstract void PlayerDetails();
        public abstract void Winner(string winner);
        public abstract void SetDifficulty();
        public abstract bool GameOver();
        public abstract void OpenHelp();
        public abstract void DisplayCommands();

        public virtual void CreateBoard()
        {
            Console.Clear();
            Board.InitiateBoard();
        }



        public virtual void SetMode()
        {
            mode = uI.SelectMode();

            if (mode == 1)
            {
                players[0] = new User();
                players[1] = new Computer();
                SetDifficulty();

            }
            else
            {
                players[0] = new User();
                players[1] = new User();
            }
        }

    }
}
