using System;

namespace TicTacToe
{
    public class GameAfterSixthMove : WinnableGame, IPlayerXsTurn<GameAfterSeventhMoveOrWonGame>
    {
        public GameAfterSixthMove(Action<WonGame> wonAction)
            : base(wonAction)
        { }
    
        public GameAfterSeventhMoveOrWonGame MoveX(Position position)
        {
            return new GameAfterSeventhMoveOrWonGame(new GameAfterSeventhMove(_wonAction));
        }
    }
}