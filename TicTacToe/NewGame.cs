using System;

namespace TicTacToe
{
    public class NewGame : RunningGame, IPlayerXsTurn<GameAfterOneMove>
    {
        // complete
        public NewGame(Action<WonGame> wonAction)
            : base(wonAction)
        { }

        public GameAfterOneMove MoveX(Position position)
        {
            Record(position);
            return new GameAfterOneMove(_wonAction);
        }
    }
}