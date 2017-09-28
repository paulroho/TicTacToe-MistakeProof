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
            var gameAfter1Move = game.MoveX(PromptForPosition(Player.X));
            var gameAfter2Move = gameAfter1Move.MoveO(PromptForPosition(Player.O));
            var gameAfter3Move = gameAfter2Move.MoveX(PromptForPosition(Player.X));
            var gameAfter4Move = gameAfter3Move.MoveO(PromptForPosition(Player.O));
            var gameAfter5MoveOrWonGame = gameAfter4Move.MoveX(PromptForPosition(Player.X));
            var gameAfter6MoveOrWonGame = gameAfter5MoveOrWonGame.OnOngoingOrWonGame(
                ongoing => ongoing.MoveO(PromptForPosition(Player.O)));
            var gameAfter7MoveOrWonGame = gameAfter6MoveOrWonGame.OnOngoingOrWonGame(
                ongoing => ongoing.MoveX(PromptForPosition(Player.X)));
            var gameAfter8MoveOrWonGame = gameAfter7MoveOrWonGame.OnOngoingOrWonGame(
                ongoing => ongoing.MoveO(PromptForPosition(Player.O)));
            var drawOrWonGame = gameAfter8MoveOrWonGame.OnOngoingOrWonGame(
                ongoing => ongoing.MoveX(PromptForPosition(Player.X)));
            drawOrWonGame.OnDrawOrWonGame(
                draw => ConfirmDraw());
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

        private void ConfirmDraw()
        {
            _outStream.WriteLine("Draw!");
        }
    }
}
