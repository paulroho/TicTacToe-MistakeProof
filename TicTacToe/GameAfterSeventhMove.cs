using System;

namespace TicTacToe
{
    public class GameAfterSeventhMove : WinnableGame, IPlayerOsTurn<GameAfterEighthMoveOrWonGame>
    {
        public GameAfterSeventhMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterEighthMoveOrWonGame MoveO(Position position)
        {
            return new GameAfterEighthMoveOrWonGame(new GameAfterEighthMove(_wonAction));
        }
    }
}