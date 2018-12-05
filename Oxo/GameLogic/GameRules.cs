using System;

namespace Oxo
{
    public static class GameRules
    {
        // Global Properties
        public static Player Player1 { get; set; } = new Player();
        public static Player Player2 { get; set; } = new Player();
        public static int NumberOfGames { get; set; }

        // Functions
        public static void StartGame(string name1, string name2)
        {
            Player1.PlayerName = name1;
            Player2.PlayerName = name2;

            NumberOfGames = 1;
        }

        public static Player DetermineStartingPlayer()
        {
            // Random number to choose player.
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 10);

            if(randomNumber < 5 )
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }

    }
}
