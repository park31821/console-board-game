using System;
using static System.Console;

namespace ConsoleBoardGame
{
    public class Board : IBoard
    { 
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string[] Positions { get; set; }

        public Board()
        {
        }

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Positions = new string[rows * columns];
        }


        public void InitiateBoard()
        {

            string[] pieces = { "<-O->", "<-X->" };
            int index_position = 0;

            for (int i = 0; i < Rows; ++i)
            {

                for (int x = 0; x < Columns; ++x)
                {
                    if (Positions[x + index_position] == null)
                    {
                        Positions[x + index_position] = (x + index_position + 1).ToString();
                    }

                    if (Array.Exists(pieces, element => element == Positions[x + index_position]))
                    {
                        Write($" {Positions[x + index_position]}  |");
                    }
                    else if (Int32.Parse(Positions[x + index_position]) < 10)
                    {
                        Write($"    {Positions[x + index_position]}   |");
                    }
                    else
                    {
                        Write($"   {Positions[x + index_position]}   |");
                    }

                }

                WriteLine("");
                WriteLine("--------------------------------------------------------------");

                index_position += Columns;

            }
        }
    }

}
