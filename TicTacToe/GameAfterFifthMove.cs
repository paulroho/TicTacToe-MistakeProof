namespace TicTacToe
{
    public class GameAfterFifthMove
    {
        public bool HasEnded => false;

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            // TODO check for winner
            if (position.Equals(new Position(Row.Top, Column.Right)))
            {
                return new GameAfterSixthMoveOrWonGame(new WonGame(Player.O));
            }
            // TODO capture position
            return new GameAfterSixthMoveOrWonGame(new GameAfterSixthMove());
        }
    }
}