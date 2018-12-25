namespace Oxo
{
    public class Player
    {
        // Properties
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public bool IsOnTurn { get; set; } = false;

        // Constructors
        public Player()
        {
        }
        public Player(string name)
        {
            PlayerName = name;
        }
    }
}
