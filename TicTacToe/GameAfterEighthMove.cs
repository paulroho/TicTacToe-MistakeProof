using System;

namespace TicTacToe
{
    public class GameAfterEighthMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterEighthMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public DrawOrWonGame MoveX(Position position)
        {
            return new DrawOrWonGame(new DrawGame());
        }
    }
}