using System;

namespace TicTacToe
{
    public interface IOngoingGameX<T>
    {
        T OnOngoingGame(Func<IPlayerXsTurn<T>, T> ongoingFunc);
    }
}