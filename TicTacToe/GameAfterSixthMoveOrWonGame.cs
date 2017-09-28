using System;

namespace TicTacToe
{
    public class GameAfterSixthMoveOrWonGame
    {
        private readonly GameAfterSixthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public GameAfterSixthMoveOrWonGame(GameAfterSixthMove ongoingGame)
        {
            _ongoingGame = ongoingGame ?? throw new ArgumentNullException(nameof(ongoingGame));
        }

        public GameAfterSixthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterSeventhMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterSixthMove, GameAfterSeventhMoveOrWonGame> ongoingFunc)
        {
            if (_wonGame != null)
            {
                _wonGame.NotifyWin();
                return new GameAfterSeventhMoveOrWonGame(_wonGame);
            }
            return ongoingFunc(_ongoingGame);
        }

    }
}