using System;
using Ping_Pong_Score.Classes;

namespace Ping_Pong_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strings for retrieving character name
            string p1, p2;

            // player one
            Console.Write("Please enter first player's name: ");
            p1 = Console.ReadLine();
            Player playerOne = new Player(p1);

            // player two
            Console.Write("Please enter second player's name: ");
            p2 = Console.ReadLine();
            Player playerTwo = new Player(p2);

            // Print player names
            Console.WriteLine("{0} vs. {1}", playerOne.ToString(), playerTwo.ToString());
            play(playerOne, playerTwo);

            Console.ReadKey();

        }

        static void play(Player playerOne, Player playerTwo)
        {
            while (true)
            {
                string tally;


                if (((playerOne.Score >= 21) || (playerTwo.Score >= 21)) && (GetPointDifference(playerOne.Score, playerTwo.Score) >= 2))
                {
                    Console.WriteLine("The winner is: {0}", GetWinner(playerOne, playerTwo));
                    Console.WriteLine("Game over!");
                    break;
                }

                Console.WriteLine("Press 1 if {0} scores. Press 2 if {1} scores.", playerOne.Name, playerTwo.Name);
                Console.WriteLine("Type exit to quit game.");
                tally = Console.ReadLine();

                if (tally.Equals("exit"))
                {
                    Console.WriteLine("Quitting game!");
                    break;
                }
                else
                {
                    byte res;
                    Byte.TryParse(tally, out res);

                    if (res == 1)
                        playerOne.IncreaseScore();
                    else if (res == 2)
                        playerTwo.IncreaseScore();
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                Console.WriteLine("Score is:\n{0}:\t{1}\n{2}:\t{3}\n", playerOne.Name, playerOne.Score, playerTwo.Name, playerTwo.Score);
            }
        }

        static int GetPointDifference(int sc1, int sc2)
        {
            // Return the absolute value of the point differential
            return Math.Abs(sc1 - sc2);
        }

        static string GetWinner(Player playerOne, Player playerTwo)
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
