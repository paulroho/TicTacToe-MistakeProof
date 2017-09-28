using System;

namespace TicTacToe.MistakeProof
{
    public class WonGame
    {
        // TODO capture previous state for queries, else complete

        private bool _once = true;

        public WonGame(Player winner)
        {
            Winner = winner;
        }

        public Player Winner { get; }

        public bool HasEnded
        {
            get { return true;  }
        }

        public void CallBackOnce(Action<WonGame> wonAction)
        {
            if (_once)
            {
                wonAction(this);
                _once = false;
            }
        }
    }
}