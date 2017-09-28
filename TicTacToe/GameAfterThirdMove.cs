using System;

namespace TicTacToe
{
    public class GameAfterThirdMove : RunningGame, IPlayerOsTurn<GameAfterFourthMove>
    {
        internal GameAfterThirdMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterFourthMove MoveO(Position position)
        {
            Record(position);
            return new GameAfterFourthMove(_wonAction);
        }
    }
}