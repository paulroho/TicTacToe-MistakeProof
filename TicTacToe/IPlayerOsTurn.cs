namespace TicTacToe
{
    public interface IPlayerOsTurn<out T> : IAnyPlayersTurn
    {
        T MoveO(Position position);
    }
}
