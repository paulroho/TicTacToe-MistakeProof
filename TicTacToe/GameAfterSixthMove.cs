using System;

namespace TicTacToe
{
    public class GameAfterSixthMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterSixthMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public bool HasEnded => false;

        public GameAfterSeventhMoveOrWonGame MoveX(Position position)
        {
            return new GameAfterSeventhMoveOrWonGame(new GameAfterSeventhMove(_wonAction));
        }
    }
}