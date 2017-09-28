namespace TicTacToe
{
    public interface IPlayerXsTurn<T>
    {
        T MoveX(Position position);
    }
}