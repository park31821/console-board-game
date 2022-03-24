using System;
namespace ConsoleBoardGame
{
    public class Invoker
    {
        private ICommand undoCommand;
        private ICommand saveCommand;
        private ICommand loadCommand;

        public Invoker(ICommand UndoCommand, ICommand SaveCommand, ICommand LoadCommand)
        {
            undoCommand = UndoCommand;
            saveCommand = SaveCommand;
            loadCommand = LoadCommand;
        }

        public void Undo()
        {
            undoCommand.Execute();
        }

        public void Redo()
        {
            undoCommand.Undo();
        }

        public void Save()
        {
            saveCommand.Execute();
        }

        public void Load()
        {
            loadCommand.Execute();
        }
    }
}
