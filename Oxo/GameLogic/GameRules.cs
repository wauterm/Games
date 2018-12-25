using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oxo
{
    public static class GameRules
    {
        // Global Properties
        public static List<Player> Players { get; set; } = new List<Player>();
        public static int NumberOfGames { get; set; } = 0;
        public static string[,] Grid = new string[4,4];
        public static Player LastWinner { get; set; } = new Player();

        // Functions
        public static void StartGame()
        {
            NumberOfGames += 1;
        }
        /// <summary>
        /// Makes a random int selection between 0 and 10 where
        /// player1 and player2 each have 50/50 chance to start.
        /// </summary>
        /// <returns>Returns player1 or player2</returns>
        public static Player DetermineStartingPlayer(Player p1, Player p2)
        {
            p1.IsOnTurn = false;
            p2.IsOnTurn = false;
            // Random number to choose player.
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 10);

            if(randomNumber < 5 )
            {
                p1.IsOnTurn = true;
                return p1;
            }
            else
            {
                p2.IsOnTurn = true;
                return p2;
            }
        }
        public static Player SwitchTurn()
        {
            if (Players[0].IsOnTurn == true)
            {
                Players[0].IsOnTurn = false;
                Players[1].IsOnTurn = true;
                return Players[1];
            }
            else
                Players[1].IsOnTurn = false;
                Players[0].IsOnTurn = true;
                return Players[0];
        }

        public static bool CheckForWinningSequence()
        {
            string[] winningSequences = { "oxoo", "ooxo", "xoxo", "oxox", "oxo", "*oxo", "oxo*"};

            for (int i = 0; i < Grid.Length / 4; i++)
            {
                if(CompareRowSequence(i, winningSequences) || CompareColumnSequence(i,winningSequences) || CompareDiagonals(winningSequences))
                {
                    if(Players[0].IsOnTurn)
                    {
                        Players[0].Score += 1;
                        LastWinner = Players[0];
                    }
                    else
                    {
                        Players[1].Score += 1;
                        LastWinner = Players[1];
                    }
                    return true;
                }
            }
            return false;
        }
        private static bool CompareRowSequence(int y, string[] winningSequence)
        {
            string comparisonSequence = string.Empty;

            for (int x = 0; x < Grid.Length / 4; x++)
            {
                if(Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y];
                }
                else
                {
                    comparisonSequence += "*";
                }
            }

            foreach (string sequence in winningSequence)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool CompareColumnSequence(int x, string[] winningSequence)
        {
            string comparisonSequence = string.Empty;

            for (int y = 0; y < Grid.Length / 4; y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y]; 
                }
                else
                {
                    comparisonSequence += "*";
                }
            }

            foreach (string sequence in winningSequence)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool CompareDiagonals(string[] winningSequences)
        {
            string comparisonSequence = string.Empty;

            // Links naar rechts
            for (int x = 0, y = 1; x < 3; x++,y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y];
                }
                else
                {
                    comparisonSequence += "*";
                }
            }
            foreach (string sequence in winningSequences)
            {
                if(comparisonSequence == sequence)
                {
                    return true;
                }
            }

            comparisonSequence = "";

            for (int x = 1, y = 0; x < 3; x++,y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y]; 
                }
                else
                {
                    comparisonSequence += "*";
                }
            }
            foreach (string sequence in winningSequences)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }

            comparisonSequence = "";

            for (int x = 0, y = 0; x < 4; x++, y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y]; 
                }
                else
                {
                    comparisonSequence += "*";
                }
            }
            foreach (string sequence in winningSequences)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }

            comparisonSequence = "";

            // Rechts naar links
            for (int x = 2, y = 0; x >= 0; x--, y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y];
                }
                else
                {
                    comparisonSequence += "*";
                }
            }
            foreach (string sequence in winningSequences)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }

            comparisonSequence = "";

            for (int x = 3, y = 1; x > 0; x--, y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y]; 
                }
                else
                {
                    comparisonSequence += "*";
                }
            }
            foreach (string sequence in winningSequences)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }

            comparisonSequence = "";

            for (int x = 3, y = 0; x >= 0; x--, y++)
            {
                if (Grid[x,y] != null)
                {
                    comparisonSequence += Grid[x, y]; 
                }
                else
                {
                    comparisonSequence += "*";
                }
            }
            foreach (string sequence in winningSequences)
            {
                if (comparisonSequence == sequence)
                {
                    return true;
                }
            }
            comparisonSequence = "";
            return false;
        }
        public static void NewGame()
        {
            Players.Clear();
        }
    }
}
