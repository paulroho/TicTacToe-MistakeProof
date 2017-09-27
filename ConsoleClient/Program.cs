using System;
using System.IO;
using TicTacToe.MistakeProof;

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
            var game = new NewGame();

            var pos = PromptForPosition(Player.X);
            var gameAfterOneMove = game.MoveX(pos);

            var gameAfterSecondMove = gameAfterOneMove.MoveO(PromptForPosition(Player.O));

            var gameAfterThirdMove = gameAfterSecondMove.MoveX(PromptForPosition(Player.X));

            var gameAfterFourthMove = gameAfterThirdMove.MoveO(PromptForPosition(Player.O));

            var gameAfterFifthMoveOrWonGame = gameAfterFourthMove.MoveX(PromptForPosition(Player.X));

            gameAfterFifthMoveOrWonGame.OnOngoingOrWonGame(
                ongoing =>
                {
                    return ongoing.MoveO(PromptForPosition(Player.O));
                },
                won => _outStream.WriteLine($"Player {won.Winner} wins!"));
        }

        private void PromptPlayerTurn(Player player)
        {
            _outStream.WriteLine($"Player {player} turn:");
        }

        private Position PromptForPosition(Player player)
        {
            PromptPlayerTurn(player);
            var position = ReadPosition();
            ConfirmPosition(player, position);
            return position;
        }

        private void ConfirmPosition(Player player, Position position)
        {
            _outStream.WriteLine($"Player {player} moved {position}");
        }

        private Position ReadPosition()
        {
            var line = _inStream.ReadLine();
            return Position.Parse(line);
        }
    }
}
