using System;

namespace TicTacToe
{
    public class GameAfterFourthMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterFourthMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public bool HasEnded => false;

        public GameAfterFifthMoveOrWonGame MoveX(Position position)
        {
            // TODO check for winner
            if (position.Equals(new Position(Row.Top, Column.Middle)))
            {
                return new GameAfterFifthMoveOrWonGame(new WonGame(_wonAction, Player.X));
            }
            // TODO capture position
            return new GameAfterFifthMoveOrWonGame(new GameAfterFifthMove(_wonAction));
        }
    }
}