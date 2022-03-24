using System;
namespace ConsoleBoardGame
{
    public class UndoCommand : ICommand
    {
        protected History history;
        private Game game;

        public UndoCommand(History history, Game game)
        {
            this.history = history;
            this.game = game;
        }

        public void Execute()
        {
            game.Board.Positions = history.UndoMove(game.Board.Positions);
        }

        public void Undo()
        {
            game.Board.Positions = history.RedoMove(game.Board.Positions);
        }

    }
}
