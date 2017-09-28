using System;

namespace TicTacToe
{
    public class GameAfterEighthMove : WinnableGame, IPlayerXsTurn<DrawOrWonGame>
    {
        public GameAfterEighthMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public DrawOrWonGame MoveX(Position position)
        {
            return new DrawOrWonGame(new DrawGame());
        }
    }
}