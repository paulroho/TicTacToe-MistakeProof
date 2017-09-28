namespace TicTacToe
{
    public class GameAfterSixthMove
    {
        public bool HasEnded => false;

        public GameAfterSeventhMoveOrWonGame MoveX(Position position)
        {
            return new GameAfterSeventhMoveOrWonGame(new GameAfterSeventhMove());
        }
    }
}