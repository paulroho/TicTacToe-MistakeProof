using System;

namespace TicTacToe
{
    public class GameAfterOneMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterOneMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public GameAfterSecondMove MoveO(Position position)
        {
            // TODO capture position
            return new GameAfterSecondMove(_wonAction);
        }
    }
}