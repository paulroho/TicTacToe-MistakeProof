using System;

namespace TicTacToe
{
    public class GameAfterThirdMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterThirdMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public GameAfterFourthMove MoveO(Position position)
        {
            // TODO capture position
            return new GameAfterFourthMove(_wonAction);
        }
    }
}