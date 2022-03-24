using System;
namespace ConsoleBoardGame
{
    public class UI
    {
        public UI()
        {
        }

        public int SelectGame()
        {
            int gameOption;

            Console.WriteLine("1. Connect Four");
            Console.WriteLine("2. Checkers");
            Console.Write("Please chooose your game (1 or 2): ");
            bool success = int.TryParse(Console.ReadLine(), out gameOption);


            while (!success || (gameOption != 1))
            {
                if (gameOption == 2)
                {
                    Console.Write("Sorry, Checkers is currently unavailalbe. Please choose Connect Four. : ");
                    success = int.TryParse(Console.ReadLine(), out gameOption);
                    Console.WriteLine("");
                }
                else
                {
                    Console.Write("Invalid input! Please enter 1 or 2.: ");
                    success = int.TryParse(Console.ReadLine(), out gameOption);
                    Console.WriteLine("");
                }
                
            }

            

            return gameOption;
        }

        public int SelectMode()
        {
            int modeOption;

            Console.WriteLine("1. 1 Player mode");
            Console.WriteLine("2. 2 Player mode");
            Console.Write("Please chooose your mode (1 or 2): ");
            bool success = int.TryParse(Console.ReadLine(), out modeOption);

            while((modeOption != 1 && modeOption != 2) || !success)
            {
                Console.WriteLine("");
                Console.Write("Invalid input! Please enter 1 or 2. : ");
                modeOption = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("");

          
            return modeOption;

        }

        public int SelectDifficulty()
        {
            int difficultyOption;

            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Hard");
            Console.Write("Please chooose your difficulty (1 or 2): ");
            bool success = int.TryParse(Console.ReadLine(), out difficultyOption);

            while ((difficultyOption != 1 && difficultyOption != 2) || !success)
            {
                Console.WriteLine("");
                Console.Write("Invalid input! Please enter 1 or 2. : ");
                success = int.TryParse(Console.ReadLine(), out difficultyOption);
            }

            Console.WriteLine("");

            return difficultyOption;
        }

    }
}
