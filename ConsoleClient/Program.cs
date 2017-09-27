using System;
using System.IO;
using TicTacToe.MistakeProof;

namespace ConsoleClient
{
    public class Program
    {
        private readonly TextWriter _outStream;
        private readonly TextReader _inStream;

        static void Main(string[] args)
        {
            // out> player X turn
            // in< m m
            // out> player X moved middle middle
            // out> player O turn
            // or
            // out> player x wins
            // or
            // out> draw

            var prog = new Program(Console.Out, Console.In);
            prog.PlayGame();
        }

        public Program(TextWriter outStream, TextReader inStream)
        {
            _outStream = outStream;
            _inStream = inStream;
        }

        public void PlayGame()
        {
            var line = _inStream.ReadLine();
            var pos = Position.Parse(line);
            // block player turn, with name and parse turn

            _outStream.WriteLine("Player X turn");
        }
    }
}
