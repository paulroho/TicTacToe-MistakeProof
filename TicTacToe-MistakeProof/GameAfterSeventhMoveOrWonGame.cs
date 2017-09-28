using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterSeventhMoveOrWonGame
    {
        private readonly GameAfterSeventhMove _ongoingGame;
        private readonly WonGame _wonGame;

        public GameAfterSeventhMoveOrWonGame(GameAfterSeventhMove ongoingGame)
        {
            _ongoingGame = ongoingGame ?? throw new ArgumentNullException(nameof(ongoingGame));
        }

        public GameAfterSeventhMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterEighthMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterSeventhMove, GameAfterEighthMoveOrWonGame> ongoingFunc, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                _wonGame.CallBackOnce(wonAction);
                return new GameAfterEighthMoveOrWonGame(_wonGame);
            }
            return ongoingFunc(_ongoingGame);
        }
    }
}