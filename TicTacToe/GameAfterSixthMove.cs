using System;

namespace TicTacToe
{
    public class GameAfterSixthMove : RunningGame, IPlayerXsTurn<GameAfterSeventhMoveOrWonGame>
    {
        internal GameAfterSixthMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }
    
        public GameAfterSeventhMoveOrWonGame MoveX(Position position)
        {
            Record(position);
            return new GameAfterSeventhMoveOrWonGame(new GameAfterSeventhMove(_wonAction));
        }
    }
}