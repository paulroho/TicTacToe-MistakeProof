using System.IO;
using FluentAssertions;
using Xunit;

namespace ConsoleClient.Tests
{
    public class GuidingTests
    {
        [Fact]
        public void BasicScenario()
        {
            string expectedOutput = @"Player X turn:
Player X moved Middle Middle
Player O turn:
Player O moved Top Left
Player X turn:
Player X moved Bottom Middle
Player O turn:
Player O moved Top Right
Player X turn:
Player X moved Top Middle
Player X wins!
";
            string inputText = @"m m
t l
b m
t r
t m
";

            var outStream = new StringWriter();
            var inStream = new StringReader(inputText);
            var prog = new ConsoleClient.Program(outStream, inStream);

            prog.PlayGame();

            outStream.ToString().Should().Be(expectedOutput);
        }
    }
}
