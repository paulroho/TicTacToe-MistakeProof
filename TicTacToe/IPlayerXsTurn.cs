namespace TicTacToe
{
    public interface IPlayerXsTurn<out T> : IAnyPlayersTurn
    {
        T MoveX(Position position);

    }
}