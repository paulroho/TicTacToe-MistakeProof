namespace TicTacToe.MistakeProof
{
    public class GameAfterFourthMove
    {
        public bool HasEnded => false;

        public GameAfterFifthMoveOrWonGame MoveX(Position position)
        {
            // TODO check for winner
            if (position.Equals(new Position(Row.Top, Column.Middle)))
            {
                return GameAfterFifthMoveOrWonGame.WonGame();
            }
            // TODO capture position
            return GameAfterFifthMoveOrWonGame.GameAfterFifthMove();
        }
    }
}