using System;

namespace TicTacToe
{
    public class GameAfterSeventhMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterSeventhMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public GameAfterEighthMoveOrWonGame MoveO(Position position)
        {
            return new GameAfterEighthMoveOrWonGame(new GameAfterEighthMove(_wonAction));
        }
    }
}