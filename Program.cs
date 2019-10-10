using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            string applicationName = "Guess Number";
            string AppVersion = "1.0.0";
            string creator = "Vitor Peixoto";

            //header
            string ApplicationHeader = applicationName + " Version: " + AppVersion.ToString() + " created by " + creator+'.';
            PrintColorMessage(ConsoleColor.Green, ApplicationHeader);

            //get user's name
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();

            Console.WriteLine("Hello {0}, Let's play a game ...", userName);

            //start game
            while (true)
            {
                //right number guess

                Random random = new Random();

                int rightNumber = random.Next(1, 10);

                Console.WriteLine("Guess a number from 1 to 10...");
                
                string userInput = Console.ReadLine();

                while (!Int32.TryParse(userInput, out int x))
                {
                    PrintColorMessage(ConsoleColor.Red, "Character invalid, please insert an integer.");

                    userInput = Console.ReadLine();
                }

                if (Int32.TryParse(userInput, out int guess))
                {

                    while (guess != rightNumber)
                    {
                        //error message
                        PrintColorMessage(ConsoleColor.Red, "You guessed wrong, try again:");

                        Int32.TryParse(Console.ReadLine(), out guess);
                    }

                    //Success message
                    PrintColorMessage(ConsoleColor.Yellow, "You guessed!!!");
                    PrintColorMessage(ConsoleColor.Yellow, "Would you like to play again? [Y ou N]");

                    string answer = Console.ReadLine().ToUpper();

                    if(answer == "Y")
                    {
                        continue;
                    }
                    else if(answer == "N")
                    {
                        PrintColorMessage(ConsoleColor.DarkBlue, "Okay " + userName + ", thanks for playing my game.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }

                }

            }
           
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
