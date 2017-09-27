using System.IO;
using FluentAssertions;
using Xunit;

namespace ConsoleClientTests
{
    public class GuidingTests
    {
        [Fact]
        public void BasicScenario()
        {
            string expectedOutput = @"Player X turn:
Player X moved middle middle
Player O turn:
Player O moved top left
Player X turn:
Player X moved top middle
Player O turn:
Player O moved top right
Player X turn:
Player X moved bottom middle
Player X wins!
";
            string inputText = @"m m
t l
t m
t r
b m
";

            var outStream = new StringWriter();
            var inStream = new StringReader(inputText);
            var prog = new ConsoleClient.Program(outStream, inStream);

            prog.PlayGame();

            outStream.ToString().Should().Be(expectedOutput);
        }
    }
}
