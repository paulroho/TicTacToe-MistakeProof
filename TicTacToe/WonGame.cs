using System;

namespace TicTacToe
{
    public class WonGame
    {
        private readonly Action<WonGame> _wonAction;
        // TODO capture previous state for queries, else complete

        private bool _once = true;

        public WonGame(Action<WonGame> wonAction, Player winner)
        {
            _wonAction = wonAction;
            Winner = winner;
        }

        public bool HasEnded = true;

        public Player Winner { get; }

        internal void NotifyWin()
        {
            if (_once)
            {
                _wonAction(this);
                _once = false;
            }
        }
    }
}