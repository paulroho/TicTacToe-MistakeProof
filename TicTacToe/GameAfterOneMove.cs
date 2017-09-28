using System;

namespace TicTacToe
{
    public class GameAfterOneMove : RunningGame, IPlayerOsTurn<GameAfterSecondMove>
    {
        internal GameAfterOneMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterSecondMove MoveO(Position position)
        {
            Record(position);
            return new GameAfterSecondMove(_wonAction);
        }
    }
}