using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterSixthMoveOrWonGame
    {
        private readonly WonGame _wonGame;
        private readonly GameAfterSixthMove _ongoingGame;

        public static GameAfterSixthMoveOrWonGame GameAfterSixthMove()
        {
            return new GameAfterSixthMoveOrWonGame(new GameAfterSixthMove());
        }

        public static GameAfterSixthMoveOrWonGame WonGame()
        {
            return new GameAfterSixthMoveOrWonGame(new WonGame(Player.O));
        }

        public GameAfterSixthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        private GameAfterSixthMoveOrWonGame(GameAfterSixthMove ongoingGame)
        {
            _ongoingGame = ongoingGame;
        }

        public GameAfterSeventhMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterSixthMove, GameAfterSeventhMoveOrWonGame> ongoingAction, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                _wonGame.CallBackOnce(wonAction);
                return new GameAfterSeventhMoveOrWonGame(_wonGame);
            }
            return ongoingAction(_ongoingGame);
        }

    }
}