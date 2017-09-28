using System;

namespace TicTacToe
{
    public class GameAfterEighthMoveOrWonGame
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

        public DrawOrWonGame OnOngoingOrWonGame(Func<GameAfterEighthMove, DrawOrWonGame> ongoingFunc, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                _wonGame.CallBackOnce(wonAction);
                return new DrawOrWonGame(_wonGame);
            }
            return ongoingFunc(_ongoingGame);
        }
    }
}