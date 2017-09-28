using System;

namespace TicTacToe
{
    public class GameAfterSeventhMove : RunningGame, IPlayerOsTurn<GameAfterEighthMoveOrWonGame>
    {
        internal GameAfterSeventhMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterEighthMoveOrWonGame MoveO(Position position)
        {
            Record(position);
            return new GameAfterEighthMoveOrWonGame(new GameAfterEighthMove(_wonAction));
        }
    }
}