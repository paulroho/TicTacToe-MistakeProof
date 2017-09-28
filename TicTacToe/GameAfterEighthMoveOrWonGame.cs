using System;

namespace TicTacToe
{
    public class GameAfterEighthMoveOrWonGame : IOngoingGameX<DrawOrWonGame>
    {
        private readonly GameAfterEighthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public GameAfterEighthMoveOrWonGame(GameAfterEighthMove ongoingGame)
        {
            _ongoingGame = ongoingGame ?? throw new ArgumentNullException(nameof(ongoingGame));
        }

        public GameAfterEighthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public DrawOrWonGame OnOngoingGame(Func<IPlayerXsTurn<DrawOrWonGame>, DrawOrWonGame> ongoingFunc)
        {
            if (_wonGame != null)
            {
                _wonGame.NotifyWin();
                return new DrawOrWonGame(_wonGame);
            }
            return ongoingFunc(_ongoingGame);
        }
    }
}