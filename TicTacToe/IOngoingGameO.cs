using System;

namespace TicTacToe
{
    public interface IOngoingGameO<T>
    {
        T OnOngoingGame(Func<IPlayerOsTurn<T>, T> ongoingFunc);
    }
}
