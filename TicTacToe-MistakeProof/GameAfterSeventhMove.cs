namespace TicTacToe.MistakeProof
{
    public class GameAfterSeventhMove
    {
        public GameAfterEighthMoveOrWonGame MoveO(Position position)
        {
            return new GameAfterEighthMoveOrWonGame(new GameAfterEighthMove());
        }
    }
}