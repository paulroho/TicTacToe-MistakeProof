namespace TicTacToe.MistakeProof
{
    public class WonGame
    {
        // TODO capture previous state for queries, else complete

        public WonGame(Player winner)
        {
            Winner = winner;
        }

        public Player Winner { get; }

        public bool HasEnded
        {
            get { return true;  }
        }
    }
}