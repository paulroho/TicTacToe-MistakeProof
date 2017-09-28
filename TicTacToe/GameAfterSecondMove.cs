using System;

namespace TicTacToe
{
    public class GameAfterSecondMove : RunningGame, IPlayerXsTurn<GameAfterThirdMove>
    {
        internal GameAfterSecondMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterThirdMove MoveX(Position position)
        {
            Record(position);
            return new GameAfterThirdMove(_wonAction);
        }
    }
}