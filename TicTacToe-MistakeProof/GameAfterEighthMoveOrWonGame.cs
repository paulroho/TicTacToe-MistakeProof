using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterEighthMoveOrWonGame
    {
        private readonly GameAfterEighthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public GameAfterEighthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame;
        }

        public GameAfterEighthMoveOrWonGame(GameAfterEighthMove ongoingGame)
        {
            _ongoingGame = ongoingGame;
        }

        public DrawOrWonGame OnOngoingOrWonGame(Func<GameAfterEighthMove, DrawOrWonGame> ongoingAction, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                _wonGame.CallBackOnce(wonAction);
                return new DrawOrWonGame(_wonGame);
            }
            return ongoingAction(_ongoingGame);
        }
    }
}