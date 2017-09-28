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

        public bool HasEnded = true;

        public Player Winner { get; }

        internal void CallBackOnce(Action<WonGame> wonAction)
        {
            if (_once)
            {
                wonAction(this);
                _once = false;
            }
        }
    }
}