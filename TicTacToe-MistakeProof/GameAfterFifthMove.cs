namespace TicTacToe.MistakeProof
{
    public class GameAfterFifthMove
    {
        public bool HasEnded => false;

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            if (Equals(position, new Position(Row.Top, Column.Right)))
                return new GameAfterSixthMoveOrWonGame(new WonGame(Player.O));
            return new GameAfterSixthMoveOrWonGame(new GameAfterSixthMove());
        }
    }
}