namespace TicTacToe.MistakeProof
{
    public class GameAfterFifthMove
    {
        public bool HasEnded => false;

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            if (Equals(position, new Position(Row.Top, Column.Right)))
                return GameAfterSixthMoveOrWonGame.WonGame();
            return GameAfterSixthMoveOrWonGame.GameAfterSixthMove();
        }
    }
}