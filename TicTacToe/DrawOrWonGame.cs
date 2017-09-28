using System;

namespace TicTacToe
{
    public class DrawOrWonGame
    {
        private readonly DrawGame _drawGame;
        private readonly WonGame _wonGame;

        public DrawOrWonGame(DrawGame drawGame)
        {
            _drawGame = drawGame ?? throw new ArgumentNullException(nameof(drawGame));
        }

        public DrawOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public void OnDrawOrWonGame(Action<DrawGame> drawAction, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                _wonGame.CallBackOnce(wonAction);
                return;
            }
            drawAction(_drawGame);
        }
    }
}