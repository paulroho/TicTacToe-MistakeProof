using FluentAssertions;
using TicTacToe.MistakeProof;
using Xunit;

namespace Tests
{
    public class PositionTests
    {
        [Fact]
        public void Parse_HappyPath()
        {
            var actual = Position.Parse("m r");

            actual.Should().Be(new Position(Row.Middle, Column.Right));
        }
    }
}