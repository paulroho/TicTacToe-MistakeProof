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
                return new GameAfterFifthMoveOrWonGame(new WonGame(Player.X));
            }
            // TODO capture position
            return new GameAfterFifthMoveOrWonGame(new GameAfterFifthMove());
        }
    }
}