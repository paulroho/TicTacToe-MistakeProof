using System;

namespace TicTacToe
{
    public class GameAfterFourthMove : WinnableGame, IPlayerXsTurn<GameAfterFifthMoveOrWonGame>
    {
        public GameAfterFourthMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterFifthMoveOrWonGame MoveX(Position position)
        {
            // TODO capture position

            // TODO check for winner
            if (position.Equals(new Position(Row.Top, Column.Middle)))
            {
                return new GameAfterFifthMoveOrWonGame(new WonGame(_wonAction, Player.X));
            }

            return new GameAfterFifthMoveOrWonGame(new GameAfterFifthMove(_wonAction));
        }
    }
}