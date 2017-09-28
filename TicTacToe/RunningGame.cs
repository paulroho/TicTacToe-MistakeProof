using System;

namespace TicTacToe
{
    /// <summary>
    /// Base class for all games which are not ended.
    /// Is this class worth the weight? Not now but maybe later.
    /// Will contain base game logic.
    /// </summary>

    public abstract class RunningGame
    {
        protected readonly Action<WonGame> _wonAction;

        protected internal RunningGame(Action<WonGame> wonAction)
        {
            _wonAction = wonAction ?? throw new ArgumentNullException(nameof(wonAction));
        }

        public bool HasEnded => false;

        protected void Record(Position position)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position));

            // TODO capture position
        }

        protected virtual bool HasWon()
        {
            // TODO check for winner
            return false;
        }

    }
}