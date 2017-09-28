using System;

namespace TicTacToe
{
    /// <summary>
    /// Base class for all games which are winnable.
    /// Is this class worth the weight? Not now but maybe later.
    /// Will contain base game logic.
    /// </summary>

    public abstract class WinnableGame
    {
        protected readonly Action<WonGame> _wonAction;

        protected internal WinnableGame(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public bool HasEnded => false;

        protected void Record(Position position)
        {
            // TODO capture position
        }

        protected virtual bool HasWon()
        {
            // TODO check for winner
            return false;
        }

    }
}