using System;

namespace TicTacToe
{
    public class GameAfterSixthMoveOrWonGame : IOngoingGameX<GameAfterSeventhMoveOrWonGame>
    {
        private readonly GameAfterSixthMove _ongoingGame;
        private readonly WonGame _wonGame;

        internal GameAfterSixthMoveOrWonGame(GameAfterSixthMove ongoingGame)
        {
            _ongoingGame = ongoingGame ?? throw new ArgumentNullException(nameof(ongoingGame));
        }

        internal GameAfterSixthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterSeventhMoveOrWonGame OnOngoingGame(Func<IPlayerXsTurn<GameAfterSeventhMoveOrWonGame>, GameAfterSeventhMoveOrWonGame> ongoingFunc)
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