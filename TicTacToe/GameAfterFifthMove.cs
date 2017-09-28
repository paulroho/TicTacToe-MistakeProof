using System;

namespace TicTacToe
{
    public class GameAfterFifthMove : WinnableGame, IPlayerOsTurn<GameAfterSixthMoveOrWonGame>
    {
        public GameAfterFifthMove(Action<WonGame> wonAction) 
            : base(wonAction)
        { }

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            // TODO capture position
            base.Record(position);

            // TODO check for winner
            if (HasWon() || position.Equals(new Position(Row.Top, Column.Right)))
            {
                return new GameAfterSixthMoveOrWonGame(new WonGame(_wonAction, Player.O));
            }

            return new GameAfterSixthMoveOrWonGame(new GameAfterSixthMove(_wonAction));
        }
    }
}