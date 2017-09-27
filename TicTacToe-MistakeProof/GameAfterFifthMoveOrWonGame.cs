using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterFifthMoveOrWonGame
    {
        // complete
        // TODO mayme make generic in GameAfterFifthMove
        private readonly GameAfterFifthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public static GameAfterFifthMoveOrWonGame GameAfterFifthMove()
        {
            return new GameAfterFifthMoveOrWonGame(new GameAfterFifthMove());
        }

        public static GameAfterFifthMoveOrWonGame WonGame()
        {
            return new GameAfterFifthMoveOrWonGame(new WonGame(Player.X));
        }

        private GameAfterFifthMoveOrWonGame(GameAfterFifthMove gameAfterFifthMove)
        {
            _ongoingGame = gameAfterFifthMove ?? throw new ArgumentNullException(nameof(gameAfterFifthMove));
        }

        private GameAfterFifthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterSixthMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterFifthMove, GameAfterSixthMoveOrWonGame> ongoingAction, Action<WonGame> wonAction)
        {
            // TODO check arguments not null
            if (_wonGame != null)
            {
                wonAction(_wonGame);
                return new GameAfterSixthMoveOrWonGame(_wonGame);
            }
            return ongoingAction(_ongoingGame);
        }
    }
}