namespace Oxo
{
    public class Player
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public bool IsOnTurn { get; set; } = false;
        public int TurnsPlayed { get; set; } = 0;
    }
}
