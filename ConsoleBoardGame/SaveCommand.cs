using System;
namespace ConsoleBoardGame
{
    public class SaveCommand : ICommand
    {
        private History history;
        private Game game;

        public SaveCommand(History history, Game game)
        {
            this.history = history;
            this.game = game;
        }

        public void Execute()
        {
            history.SaveGame(game);
        }

        public void Undo()
        {
        }
    }
}
