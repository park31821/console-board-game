using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleBoardGame
{
    public class History
    {
        const string PATH = "../../../save/savefile.txt";

        private List<int> moves = new List<int>();
        private List<string[]> savedList = new List<string[]>();
        private string undoPiece1;
        private string undoPiece2;
        private int undoIndex1;
        private int undoIndex2;
        public string[] loadedMoves;

        private History()
        {
            
        }

        private static History history = null;

        public static History getHistory()
        {
            if (history == null)
            {
                history = new History();
            }

            return history;
        }

        public void SaveMove(int displayedPosition)
        {
            int index = displayedPosition - 1;
            moves.Add(index);

        }

        public string[] UndoMove(string[] positions)
        {
            if(moves.Count > 1)
            {
                undoIndex1 = moves[moves.Count - 1];
                undoIndex2 = moves[moves.Count - 2];
                moves.RemoveAt(moves.Count - 1);
                moves.RemoveAt(moves.Count - 1);

                undoPiece1 = positions[undoIndex1];
                undoPiece2 = positions[undoIndex2];

                positions[undoIndex1] = (undoIndex1 + 1).ToString();
                positions[undoIndex2] = (undoIndex2 + 1).ToString();

            }

            return positions;

        }

        public string[] RedoMove(string[] positions)
        {
            if(!moves.Contains(undoIndex1) && !moves.Contains(undoIndex2))
            {
                moves.Add(undoIndex2);
                moves.Add(undoIndex1);

                positions[undoIndex2] = undoPiece2;
                positions[undoIndex1] = undoPiece1;

            }

            return positions;

        }

        public void SaveGame(Game currentGame)
        {
            string gameName = currentGame.GameName;
            string mode;
            string date = (DateTime.Now).ToString();

            List<string> saveInfo = new List<string>();

            if (currentGame.mode == 1)
            {
                mode = "1 Player";
            }
            else
            {
                mode = "2 Players";
            }

            saveInfo.Add(gameName);
            saveInfo.Add(date);
            saveInfo.Add(mode);
            foreach (int index in moves)
            {
                saveInfo.Add(index.ToString());
            }

            if (!File.Exists(PATH))
            {
                using (StreamWriter sw = File.CreateText(PATH))
                {
                    sw.WriteLine(string.Join(",", saveInfo));
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(PATH))
                {
                    sw.WriteLine(string.Join(",", saveInfo));
                }
            }
        }

        public void LoadGame()
        {
            string[] none = new string[0];
            int intInput;
            int saveFileIndex;
            bool success;


            Console.Write("Please enter a save file number to be loaded or nothing to create a new game.: ");
            string input = Console.ReadLine();
            Console.WriteLine("");

            if (input == "")
            {
                loadedMoves = none;
            }
            else
            {
                success = int.TryParse(input, out intInput);
                

                while (!success || intInput > savedList.Count)
                {
                    Console.Write("Invalid input! Please enter a valid save file number.: ");
                    success = int.TryParse(Console.ReadLine(), out intInput);
                    Console.WriteLine("");
                }

                saveFileIndex = intInput - 1;

                foreach (string index in savedList[saveFileIndex][3..])
                {
                    moves.Add(int.Parse(index));
                }

                loadedMoves = savedList[saveFileIndex][2..];
            }

            
        }

        public bool CheckFile(string gameType)
        {
            int saveFileNumber = 1;

            Console.WriteLine("Checking save files....");
            Console.WriteLine("");

            if (File.Exists(PATH))
            {
                using (StreamReader sr = new StreamReader(PATH))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(gameType))
                        {
                            savedList.Add(line.Split(","));
                        }
                    }
                }

            }

            if(savedList.Count < 1)
            {
                Console.WriteLine("No save files found!");
                Console.WriteLine("");
                return false;
            }

            Console.WriteLine("Save Files Found!");
            Console.WriteLine("");
            foreach (string[] line in savedList)
            {
                string date = line[1];
                string mode = line[2];
                Console.WriteLine($"{saveFileNumber}. Date: {date}, Mode: {mode}");
                ++saveFileNumber;
            }
            Console.WriteLine("");

            return true;
        }

        public void ClearSavedList()
        {
            savedList = new List<string[]>();
        }
    }
}
