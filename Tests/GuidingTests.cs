using System;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class GuidingTests
    {
        [Fact]
        public void GuidingTest()
        {
            var game = new NewGame();
            var after1 = game.MoveX(At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Bottom, Column.Middle));
            var after4 = after3.MoveO(At(Row.Top, Column.Right));
            var after5 = after4.MoveX(At(Row.Top, Column.Middle));

            Assert.Equal(Player.X, after5.Winner);
        }

        private Position At(Row middle, Column p1)
        {
            throw new NotImplementedException();
        }
    }

    internal enum Column
    {
        Middle,
        Left,
        Right
    }

    internal enum Row
    {
        Middle,
        Top,
        Bottom
    }

    public class NewGame
    {
        public GameAfterOneMove MoveX(Position position)
        {
            throw new NotImplementedException();
        }
    }

    public class Position
    {
    }

    public class GameAfterOneMove
    {
        public GameAfterSecondMove MoveO(Position position)
        {
            throw new NotImplementedException();
        }
    }

    public class GameAfterSecondMove
    {
        public GameAfterThirdMove MoveX(Position position)
        {
            throw new NotImplementedException();
        }
    }

    public class GameAfterThirdMove
    {
        public GameAfterFourthMove MoveO(Position position)
        {
            throw new NotImplementedException();
        }
    }

    public class GameAfterFourthMove
    {
        public WonGame MoveX(Position position)
        {
            throw new NotImplementedException();
        }
    }

    public class WonGame
    {
        public Player Winner { get; }
    }

    public enum Player
    {
        X
    }
}
