namespace TicTacToe.MistakeProof
{
    public class GameAfterFifthMove
    {
        public bool HasEnded => false;

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            // TODO same as in GameAfterFourthMove
            return GameAfterSixthMoveOrWonGame.WonGame();
        }
    }
}