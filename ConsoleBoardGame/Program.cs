using System;
using static System.Console;
 

namespace ConsoleBoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UI uI = new UI();
            int undoNumber = -1;
            int redoNumber = -2;
            int saveNumber = -3;
            int helpNumber = -4;

            Game game;

            while (true)
            {
                int savedMoveIndex = 0;
                Clear();

                WriteLine("Welcome to our game program!");

                int gameType = uI.SelectGame();
                var history = History.getHistory();

                if (gameType == 1)
                {
                    game = new ConnectFour();
                
                }
                else
                {
                    game = new ConnectFour();
                }

                var undo = new UndoCommand(history, game);
                var save = new SaveCommand(history, game);
                var load = new LoadCommand(history);
                var commands = new Invoker(undo, save, load);

                history.ClearSavedList();
                bool saveExist = history.CheckFile(game.GameName);

                if (saveExist)
                {
                    commands.Load();
                    string[] saveFile = history.loadedMoves;

                    if (saveFile.Length > 0)
                    {
                        string[] savedMoves = saveFile[1..];

                        if (saveFile[0] == "1 Player")
                        {
                            game.mode = 1;
                            game.SetMode();
                        }
                        else
                        {
                            game.mode = 2;
                            game.SetMode();
                        }

                        while (savedMoveIndex < savedMoves.Length)
                        {
                            foreach (Player player in game.players)
                            {
                                try
                                {
                                    int index = int.Parse(savedMoves[savedMoveIndex]);
                                    game.Board.Positions[index] = player.Piece;
                                    ++savedMoveIndex;
                                }
                                catch
                                {
                                    Player player1 = game.players[0];
                                    game.players[0] = game.players[1];
                                    game.players[1] = player1;

                                    ++savedMoveIndex;
                                    continue;
                                }
                            }
                        }

                    }
                    else
                    {
                        saveExist = false;
                    }
                }

                if(!saveExist)
                {
                    WriteLine($"Welcome to {game.GameName}!");
                    game.SetMode();
                }


                WriteLine("");
                game.CreateBoard();
                game.PlayerDetails();

                while (game.gameOn)
                {
                    foreach (Player player in game.players)
                    {
                        game.DisplayCommands();
                        int position = player.MakeMove(game.Board.Positions);

                        while (position == undoNumber || position == redoNumber || position == saveNumber || position == helpNumber)
                        {
                            if(position == undoNumber)
                            {
                                commands.Undo();
                            }
                            else if(position == redoNumber)
                            {
                                commands.Redo();
                            }
                            else if(position == saveNumber)
                            {
                                commands.Save();
                                WriteLine("Game Saved!");
                            }
                            else
                            {
                                game.OpenHelp();
                            }

                            game.CreateBoard();
                            game.DisplayCommands();
                            position = player.MakeMove(game.Board.Positions);
                        }


                        while (position > game.BoardLength || !game.IsValid(position))
                        {
                            WriteLine("Invalid Input!");
                            position = player.MakeMove(game.Board.Positions);
                        }

                        game.UpdateBoard(player.Piece, position);
                        history.SaveMove(position);
                        bool isEnd = game.GameOver();

                        if (isEnd)
                        {
                            game.Winner(player.Name);
                            WriteLine("");
                            game.gameOn = false;
                            break;
                        }
                    }
                }

                Write("Would you like to play another game? (Y/N): ");
                string replay = Console.ReadLine();

                if(replay.ToUpper() == "Y")
                {
                    continue;
                }
                else
                {
                    WriteLine("");
                    WriteLine("Thank you for playing. See you next time!");
                    break;
                }
            }

        }
    }
}
