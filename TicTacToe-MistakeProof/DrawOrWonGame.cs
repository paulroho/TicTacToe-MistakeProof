using System;

namespace TicTacToe.MistakeProof
{
    public class DrawOrWonGame
    {
        private readonly WonGame _wonGame;
        private readonly DrawGame _drawGame;

        public DrawOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame;
        }

        public DrawOrWonGame(DrawGame drawGame)
        {
            _drawGame = drawGame;
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