using System;

namespace TicTacToe
{
    public class GameAfterFourthMove : RunningGame, IPlayerXsTurn<GameAfterFifthMoveOrWonGame>
    {
        internal GameAfterFourthMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterFifthMoveOrWonGame MoveX(Position position)
        {
            Record(position);

            // TODO check for winner
            if (HasWon() || position.Equals(new Position(Row.Top, Column.Middle)))
            {
                return new GameAfterFifthMoveOrWonGame(new WonGame(_wonAction, Player.X));
            }

            return new GameAfterFifthMoveOrWonGame(new GameAfterFifthMove(_wonAction));
        }
    }
}