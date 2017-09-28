using System;

namespace TicTacToe
{
    public class GameAfterFifthMoveOrWonGame
    {
        // complete
        // TODO mayme make generic in GameAfterFifthMove
        private readonly GameAfterFifthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public GameAfterFifthMoveOrWonGame(GameAfterFifthMove ongoingGame)
        {
            _ongoingGame = ongoingGame ?? throw new ArgumentNullException(nameof(ongoingGame));
        }

        public GameAfterFifthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterSixthMoveOrWonGame OnOngoingGame(Func<GameAfterFifthMove, GameAfterSixthMoveOrWonGame> ongoingFunc)
        {
            // TODO check arguments not null
            if (_wonGame != null)
            {
                _wonGame.NotifyWin();
                return new GameAfterSixthMoveOrWonGame(_wonGame);
            }
            return ongoingFunc(_ongoingGame);
        }
    }
}