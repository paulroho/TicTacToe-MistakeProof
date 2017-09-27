namespace TicTacToe.MistakeProof
{
    public class GameAfterSixthMove
    {
        public bool HasEnded => false;

        public GameAfterSeventhMoveOrWonGame MoveX(Position promptForPosition)
        {
            return GameAfterSeventhMoveOrWonGame.GameAfterSeventhMove();
        }
    }
}