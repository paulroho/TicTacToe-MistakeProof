using System;

namespace TicTacToe
{
    public class GameAfterSeventhMoveOrWonGame : IOngoingGameO<GameAfterEighthMoveOrWonGame>
    {
        private readonly GameAfterSeventhMove _ongoingGame;
        private readonly WonGame _wonGame;

        internal GameAfterSeventhMoveOrWonGame(GameAfterSeventhMove ongoingGame)
        {
            _ongoingGame = ongoingGame ?? throw new ArgumentNullException(nameof(ongoingGame));
        }

        internal GameAfterSeventhMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterEighthMoveOrWonGame OnOngoingGame(Func<IPlayerOsTurn<GameAfterEighthMoveOrWonGame>, GameAfterEighthMoveOrWonGame> ongoingFunc)
        {
            if (ongoingFunc == null)
                throw new ArgumentNullException(nameof(ongoingFunc));

            if (_wonGame != null)
            {
                _wonGame.NotifyWin();
                return new GameAfterEighthMoveOrWonGame(_wonGame);
            }
            return ongoingFunc(_ongoingGame);
        }
    }
}