using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterFifthMoveOrWonGame
    {
        // complete
        // TODO mayme make generic in GameAfterFifthMove
        private readonly GameAfterFifthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public GameAfterFifthMoveOrWonGame(GameAfterFifthMove gameAfterFifthMove)
        {
            _ongoingGame = gameAfterFifthMove ?? throw new ArgumentNullException(nameof(gameAfterFifthMove));
        }

        public GameAfterFifthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterSixthMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterFifthMove, GameAfterSixthMoveOrWonGame> ongoingAction, Action<WonGame> wonAction)
        {
            // TODO check arguments not null
            if (_wonGame != null)
            {
                _wonGame.CallBackOnce(wonAction);
                return new GameAfterSixthMoveOrWonGame(_wonGame);
            }
            return ongoingAction(_ongoingGame);
        }
    }
}