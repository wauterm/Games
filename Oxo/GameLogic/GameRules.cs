using System;
using System.Collections.Generic;
using System.Data;
using Oxo.GameLogic;

namespace Oxo
{
    public static class GameRules
    {
        // Het spel bestaat uit:
        // Twee spelers met een naam en een score
        // 16 zetten waarbij de winnaar wordt bepaald door de sequentie "oxo"
        // De sequenties kan ik eventueel bijhouden in een lijsten ( verticaal/ kolom, horizontaal/ rij, schuinLR/ rij, schuinRL/ rij)
        // Rondes: de winnaar van een ronde krijgt een punt

        // Global Properties
        public static List<Player> Players { get; set; } = new List<Player>();
        public static int NumberOfGames { get; set; } = 0;
        public static List<OxoSquare> GridList { get; set; } = new List<OxoSquare>();
        public static string[,] Grid = new string[4,4];



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
            string[] winningSequences = { "oxoo", "ooxo", "xoxo", "oxox", "oxo"};
            // Check all 4 rows
            for (int i = 0; i < Grid.Length / 4; i++)
            {
                if(CompareRowSequence(i, winningSequences))
                {
                    return true;
                }
            }

            // Check all 4 columns
            for (int i = 0; i < Grid.Length / 4; i++)
            {
                if(CompareColumnSequence(i,winningSequences))
                {
                    return true;
                }
            }

            // Check all diagonals
            if(CompareDiagonals(winningSequences))
            {
                return true;
            }
            return false;
        }

        private static bool CompareRowSequence(int rowRank, string[] winningSequence)
        {
            string comparisonSequence = string.Empty;

            for (int i = 0; i < Grid.Length / 4; i++)
            {
                comparisonSequence += Grid[rowRank, i];
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
        private static bool CompareColumnSequence(int columnRank, string[] winningSequence)
        {
            string comparisonSequence = string.Empty;

            for (int i = 0; i < Grid.Length / 4; i++)
            {
                comparisonSequence += Grid[i, columnRank];
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
                comparisonSequence += Grid[x, y];
            }
            foreach (string sequence in winningSequences)
            {
                if(comparisonSequence == sequence)
                {
                    return true;
                }
            }

            comparisonSequence = "";

            for (int x = 1, y = 0; x < 4; x++,y++)
            {
                comparisonSequence += Grid[x, y];
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
                comparisonSequence += Grid[x, y];
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
                comparisonSequence += Grid[x, y];
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
                comparisonSequence += Grid[x, y];
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
                comparisonSequence += Grid[x, y];
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
