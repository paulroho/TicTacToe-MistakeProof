using System;

namespace TicTacToe
{
    public class DrawOrWonGame
    {
        private readonly DrawGame _drawGame;
        private readonly WonGame _wonGame;

        internal DrawOrWonGame(DrawGame drawGame)
        {
            _drawGame = drawGame ?? throw new ArgumentNullException(nameof(drawGame));
        }

        internal DrawOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public void OnDrawGame(Action<DrawGame> drawAction)
        {
            if (drawAction == null)
                throw new ArgumentNullException(nameof(drawAction));

            if (_wonGame != null)
            {
                _wonGame.NotifyWin();
                return;
            }
            drawAction(_drawGame);
        }
    }
}