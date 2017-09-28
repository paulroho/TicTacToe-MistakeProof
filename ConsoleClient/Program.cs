using System;
using System.IO;
using TicTacToe;

namespace ConsoleClient
{
    public class Program
    {
        private readonly TextWriter _outStream;
        private readonly TextReader _inStream;

        static void Main()
        {
            var prog = new Program(Console.Out, Console.In);
            prog.PlayGame();
        }

        public Program(TextWriter outStream, TextReader inStream)
        {
            _outStream = outStream;
            _inStream = inStream;
        }

        // out> player X turn
        // in< m m
        // out> player X moved middle middle
        // out> player O turn
        // or
        // out> player x wins
        // or
        // out> draw

        public void PlayGame()
        {
            var game = new NewGame(ConfirmWinner);
            var gameAfter1Move = TurnPlayerX(game);
            var gameAfter2Move = TurnPlayerO(gameAfter1Move);
            var gameAfter3Move = TurnPlayerX(gameAfter2Move);
            var gameAfter4Move = TurnPlayerO(gameAfter3Move);
            var gameAfter5Move = TurnPlayerX(gameAfter4Move);
            var gameAfter6Move = TurnPlayerO(gameAfter5Move);
            var gameAfter7Move = TurnPlayerX(gameAfter6Move);
            var gameAfter8Move = TurnPlayerO(gameAfter7Move);
            var drawOrWonGame = TurnPlayerX(gameAfter8Move);
            drawOrWonGame.OnDrawGame(ConfirmDraw);
        }

        private T TurnPlayerO<T>(IOngoingGameO<T> game)
        {
            return game.OnOngoingGame(TurnPlayerO);
        }

        private T TurnPlayerX<T>(IOngoingGameX<T> game)
        {
            return game.OnOngoingGame(TurnPlayerX);
        }

        private T TurnPlayerX<T>(IPlayerXsTurn<T> game)
        {
            return game.MoveX(PromptForPosition(Player.X));
        }

        private T TurnPlayerO<T>(IPlayerOsTurn<T> game)
        {
            return game.MoveO(PromptForPosition(Player.O));
        }

        private Position PromptForPosition(Player player)
        {
            PromptPlayerTurn(player);
            var position = ReadPosition();
            ConfirmPosition(player, position);
            return position;
        }

        private void PromptPlayerTurn(Player player)
        {
            _outStream.WriteLine($"Player {player} turn:");
        }

        private Position ReadPosition()
        {
            var line = _inStream.ReadLine();
            return Position.Parse(line);
        }

        private void ConfirmPosition(Player player, Position position)
        {
            _outStream.WriteLine($"Player {player} moved {position}");
        }

        private void ConfirmWinner(WonGame won)
        {
            _outStream.WriteLine($"Player {won.Winner} wins!");
        }

        private void ConfirmDraw(DrawGame draw)
        {
            _outStream.WriteLine("Draw!");
        }
    }
}
