using System;

namespace TicTacToe
{
    public class NewGame
    {
        private readonly Action<WonGame> _wonAction;

        public NewGame(Action<WonGame> wonAction)
        {
            _wonAction = wonAction;
        }

        public GameAfterOneMove MoveX(Position position)
        {
            // TODO capture position
            return new GameAfterOneMove(_wonAction);
        }
    }
}