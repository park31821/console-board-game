using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleBoardGame
{
    public class ConnectFourReq : Requirements
    {
        const int NEXTLINE = 7;
        string url = "https://en.wikipedia.org/wiki/Connect_Four#:~:text=The%20two%20players%20then%20alternate,the%20game%20is%20a%20draw.";
        string[] pieces = { "<-O->", "<-X->" };
        int[] lastLine = { 35, 36, 37, 38, 39, 40, 41 };
        int[][] firstFourIndex =
            {
                new int[] {0,1,2,3},
                new int[] {7,8,9,10},
                new int[] {14,15,16,17},
                new int[] {21,22,23,24},
                new int[] {28,29,30,31},
                new int[] {35,36,37,38}
            };

        private ConnectFourReq()
        {
        }

        private static ConnectFourReq requirements = null;

        public static ConnectFourReq getRequirements()
        {
            if (requirements == null)
            {
                requirements = new ConnectFourReq();
            }

            return requirements;
        }

        public override int CalculateMoves(string piece, string[] positions)
        {
            List<int> availableIndex = new List<int>();
            List<int> indexForThree = new List<int>();
            List<int> indexForTwo = new List<int>();
            List<int> indexForOne = new List<int>();
            List<List<int>> SelectedIndexes = new List<List<int>>();

            int[] directions = { 1, -1, 6, -6, 7, -7, 8, -8 };

            int index = 0;
            Random random = new Random();

            foreach (string x in positions)
            {
                int numb;
                bool success = Int32.TryParse(x, out numb);

                if (success)
                {
                    bool isValid = InputValidator(numb, positions);

                    if (isValid)
                    {
                        availableIndex.Add(numb);

                    }

                }

            }

            // Checking best available index in the board. indexForThree indicates there are three pieces connected to the available index.

            if (Difficulty == 1)
            {
                index = availableIndex[random.Next(availableIndex.Count)];
                return index;
            }
            else
            {
                foreach (int position in availableIndex)
                {
                    int realIndex = position - 1;

                    foreach (int d in directions)
                    {
                        if ((realIndex + d) < positions.Length && (realIndex + d) > 0)
                        {
                            if (piece == positions[realIndex + d])
                            {
                                indexForOne.Add(position);

                                if ((realIndex + (d * 2)) < positions.Length && (realIndex + (d * 2)) > 0)
                                {
                                    if (piece == positions[realIndex + (d * 2)])
                                    {
                                        indexForTwo.Add(position);

                                        if ((position + (d * 3)) < positions.Length && (position + (d * 3)) > 0)
                                        {
                                            if (piece == positions[position + (d * 3)])
                                            {
                                                indexForThree.Add(position);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    SelectedIndexes.Add(indexForThree);
                    SelectedIndexes.Add(indexForTwo);
                    SelectedIndexes.Add(indexForOne);

                }

                for(int i=0; i<SelectedIndexes.Count; ++i)
                {
                    if(SelectedIndexes[i].Count > 0)
                    {
                        index = SelectedIndexes[i][random.Next(SelectedIndexes[i].Count)];
                        break;
                    }
                }

                if (index == 0)
                {
                    index = availableIndex[random.Next(availableIndex.Count)];
                }

            }

            return index;
        }
 

        public override bool CheckWinner(string[] positions)
        {
            bool isEnd = false;
            int[] directions = { 1, -6, 7, -7, 8 };

            for (int x = 0; x < positions.Length; ++x)
            {

                int position;
                bool success = Int32.TryParse(positions[x], out position);

                if (!success)
                {
                    foreach (int d in directions)
                    {

                        if (d == 7 || d == -7)
                        {
                            if ((x + (d * 3)) < positions.Length && (x + (d * 3)) > 0)
                            {
                                if ((positions[x] == positions[x + d])
                                && (positions[x + d] == positions[x + (d * 2)])
                                && (positions[x + (d * 2)] == positions[x + (d * 3)]))
                                {
                                    isEnd = true;
                                }
                            }

                        }

                        // firsFourIndex is first four index of a line, to make sure index does not exceed while calculating different directions.

                        else
                        {
                            foreach (int[] line in firstFourIndex)
                            {
                                foreach (int i in line)
                                {
                                    if ((i + (d * 3)) < positions.Length && (i + (d * 3)) > 0)
                                    {
                                       if ((positions[i] == positions[i + d]
                                       && positions[i + d] == positions[i + (d * 2)]
                                       && positions[i + (d * 2)] == positions[i + (d * 3)]))

                                       {
                                            isEnd = true;

                                       }
                                    }  

                                }

                            }
                        }
                    }
                }
            }

            return isEnd;
        }

        public override void DisplayHelp()
        {
            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            Process.Start(psi);
        }

        public override bool InputValidator(int position, string[] positions)
        {
            if(position < 1)
            {
                return false;
            }

            int index = position - 1;
            
            if (Array.Exists(pieces, piece => piece == positions[index]))
            {
                return false;
            }
            else if(Array.Exists(lastLine, position => position == index))
            {
                return true;
            }
            else
            {
                if (Array.Exists(pieces, piece => piece == positions[index + NEXTLINE]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void DisplayCommands()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------Commands----------------");
            Console.WriteLine("'-1' to undo previous command.");
            Console.WriteLine("'-2' to redo your command.");
            Console.WriteLine("'-3' to save your game.");
            Console.WriteLine("'-4' to open the game documentation.");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
        }
    }
}
