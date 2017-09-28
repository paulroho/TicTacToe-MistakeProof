using System;

namespace TicTacToe
{
    public class GameAfterFifthMove
    {
        private readonly Action<WonGame> _wonAction;

        public GameAfterFifthMove(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public bool HasEnded => false;

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            // TODO check for winner
            if (position.Equals(new Position(Row.Top, Column.Right)))
            {
                return new GameAfterSixthMoveOrWonGame(new WonGame(_wonAction, Player.O));
            }
            // TODO capture position
            return new GameAfterSixthMoveOrWonGame(new GameAfterSixthMove(_wonAction));
        }
    }
}