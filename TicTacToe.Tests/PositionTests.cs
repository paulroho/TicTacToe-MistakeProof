using FluentAssertions;
using Xunit;

namespace TicTacToe.Tests
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