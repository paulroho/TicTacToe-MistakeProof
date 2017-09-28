namespace TicTacToe
{
    public class GameAfterEighthMove
    {
        public DrawOrWonGame MoveX(Position position)
        {
            return new DrawOrWonGame(new DrawGame());
        }
    }
}