using System;

namespace TicTacToe
{
    public class GameAfterEighthMove : RunningGame, IPlayerXsTurn<DrawOrWonGame>
    {
        internal GameAfterEighthMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public DrawOrWonGame MoveX(Position position)
        {
            Record(position);
            return new DrawOrWonGame(new DrawGame());
        }
    }
}