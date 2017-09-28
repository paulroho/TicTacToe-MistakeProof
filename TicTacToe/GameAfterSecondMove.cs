using System;

namespace TicTacToe
{
    public class GameAfterSecondMove : IPlayerXsTurn<GameAfterThirdMove>
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterSecondMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public GameAfterThirdMove MoveX(Position position)
        {
            // TODO capture position
            return new GameAfterThirdMove(_wonAction);
        }
    }
}