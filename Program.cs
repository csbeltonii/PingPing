using System;
using Ping_Pong_Score.Classes;

namespace Ping_Pong_Score
{
    class Program
    {
        public static void Main(string[] args)
        {
            // player one
            Console.Write("Please enter first player's name: ");
            var p1 = Console.ReadLine();
            var playerOne = new Player(p1);

            // player two
            Console.Write("Please enter second player's name: ");
            var p2 = Console.ReadLine();
            var playerTwo = new Player(p2);

            // Print player names
            Console.WriteLine("{0} vs. {1}", playerOne.ToString(), playerTwo.ToString());
            Play(playerOne, playerTwo);

            Console.ReadKey();
        }

        private static void Play(Player playerOne, Player playerTwo)
        {

            var srvCtr = 0; // Players switch every five serves
            var serve = true; // determines which player serves; true for p1, false for p1

            while (true)
            {
                if (((playerOne.Score >= 21) || (playerTwo.Score >= 21)) && (GetPointDifference(playerOne.Score, playerTwo.Score) >= 2))
                {
                    Console.WriteLine("The winner is: {0}", GetWinner(playerOne, playerTwo));
                    Console.WriteLine("Game over!");
                    break;
                }

                srvCtr++;

                if (serve)
                {
                    Console.WriteLine("{0} serves.", playerOne.Name);

                    if (srvCtr % 5 == 0)
                        serve = false;
                }
                else
                {
                    Console.WriteLine("{0} serves.", playerTwo.Name);

                    if (srvCtr % 5 == 0)
                        serve = true;
                }


                Console.WriteLine("Press 1 if {0} scores. Press 2 if {1} scores.", playerOne.Name, playerTwo.Name);
                Console.WriteLine("Type exit to quit game.");
                var tally = Console.ReadLine();

                if (tally.Equals("exit"))
                {
                    Console.WriteLine("Quitting game!");
                    break;
                }
                else
                {
                    byte.TryParse(tally, out var res);

                    if (res == 1)
                        playerOne.IncreaseScore();
                    else if (res == 2)
                        playerTwo.IncreaseScore();
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                Console.WriteLine("Score is:\n{0}:\t\t{1}\n{2}:\t\t{3}\n", playerOne.Name, playerOne.Score, playerTwo.Name, playerTwo.Score);
            }
        }

        static int GetPointDifference(int sc1, int sc2)
        {
            // Return the absolute value of the point differential
            return Math.Abs(sc1 - sc2);
        }

        private static string GetWinner(Player playerOne, Player playerTwo)
        {
            int sc1 = playerOne.Score, sc2 = playerTwo.Score;

            if (sc1 > sc2)
                return playerOne.Name;
            else
            {
                return playerTwo.Name;
            }
        }
    }
}
