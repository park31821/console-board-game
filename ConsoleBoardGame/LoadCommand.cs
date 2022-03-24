using System;
namespace ConsoleBoardGame
{
    public class LoadCommand: ICommand
    {
        private History history;

        public LoadCommand(History history)
        {
            this.history = history;
        }

        public void Execute()
        {
            history.LoadGame();
        }

        public void Undo()
        {
        }
    }
}
