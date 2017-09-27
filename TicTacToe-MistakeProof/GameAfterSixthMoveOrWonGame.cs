using System;

namespace TicTacToe.MistakeProof
{
    public class GameAfterSixthMoveOrWonGame
    {
        private readonly WonGame _wonGame;

        public static GameAfterSixthMoveOrWonGame WonGame()
        {
            return new GameAfterSixthMoveOrWonGame(new WonGame(Player.O));
        }

        public GameAfterSixthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public void OnOngoingOrWonGame(Action<GameAfterSixthMove> ongoingAction, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                wonAction(_wonGame);
                //return new GameAfterSixthMoveOrWonGame(_wonGame);
            }
            //return ongoingAction(_ongoingGame);
        }

    }
}