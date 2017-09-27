using System;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class GuidingTests
    {
        [Fact]
        public void MinimalGameWhereXWins()
        {
            var game = new NewGame();
            var after1 = game.MoveX(At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Bottom, Column.Middle));
            var after4 = after3.MoveO(At(Row.Top, Column.Right));
            var after5 = after4.MoveX(At(Row.Top, Column.Middle));

            Assert.Equal(Player.X, after5.Winner);
            Assert.True(after5.HasEnded);
        }

        [Fact]
        public void GameOfFiveMovesNoWinnerYet()
        {
            var game = new NewGame();
            var after1 = game.MoveX(At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Bottom, Column.Middle));
            var after4 = after3.MoveO(At(Row.Top, Column.Middle));
            var after5 = after4.MoveX(At(Row.Top, Column.Right));

            Assert.False(after5.HasEnded);
        }

        private Position At(Row row, Column column)
        {
            return new Position(row, column);
        }
    }

    public enum Column
    {
        Middle,
        Left,
        Right
    }

    public enum Row
    {
        Middle,
        Top,
        Bottom
    }

    public class NewGame
    {
        public GameAfterOneMove MoveX(Position position)
        {
            return new GameAfterOneMove();
        }
    }

    public class Position
    {
        private readonly Row row;
        private readonly Column column;

        public Position(Row row, Column column)
        {
            this.row = row;
            this.column = column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj) || obj.GetType() != this.GetType())
            {
                return false;
            }
            Position that = (Position) obj;
            return this.row == that.row && this.column == that.column;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) row * 397) ^ (int) column;
            }
        }
    }

    public class GameAfterOneMove
    {
        public GameAfterSecondMove MoveO(Position position)
        {
            return new GameAfterSecondMove();
        }
    }

    public class GameAfterSecondMove
    {
        public GameAfterThirdMove MoveX(Position position)
        {
            return new GameAfterThirdMove();
        }
    }

    public class GameAfterThirdMove
    {
        public GameAfterFourthMove MoveO(Position position)
        {
            return new GameAfterFourthMove();
        }
    }

    public class GameAfterFourthMove
    {
        public WonGame MoveX(Position position)
        {
            return new WonGame();
        }
    }

    public class WonGame
    {
        public Player Winner
        {
            get { return Player.X; }
        }

        public bool HasEnded
        {
            get { return true;  }
        }
    }

    public enum Player
    {
        X
    }
}
