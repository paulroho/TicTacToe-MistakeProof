using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterSeventhMoveOrWonGame
    {
        private readonly GameAfterSeventhMove _ongoingGame;
        private readonly WonGame _wonGame;

        public static GameAfterSeventhMoveOrWonGame GameAfterSeventhMove()
        {
            return new GameAfterSeventhMoveOrWonGame(new GameAfterSeventhMove());
        }

        public static GameAfterSeventhMoveOrWonGame WonGame()
        {
            return new GameAfterSeventhMoveOrWonGame(new WonGame(Player.X));
        }

        private GameAfterSeventhMoveOrWonGame(GameAfterSeventhMove gameAfterFifthMove)
        {
            _ongoingGame = gameAfterFifthMove ?? throw new ArgumentNullException(nameof(gameAfterFifthMove));
        }

        internal GameAfterSeventhMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterEighthMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterSeventhMove, GameAfterEighthMoveOrWonGame> ongoingAction, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                wonAction(_wonGame);
                return new GameAfterEighthMoveOrWonGame(_wonGame);
            }
            return ongoingAction(_ongoingGame);
        }
    }
}