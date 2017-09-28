using TicTacToe.MistakeProof;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class GuidingTests
    {
        [Fact]
        public void MinimalGameWhereXWins()
        {
            // OXO
            // .X.
            // .X.
            var game = new NewGame();
            var after1 = game.MoveX(At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Bottom, Column.Middle));
            var after4 = after3.MoveO(At(Row.Top, Column.Right));

            var after5 = after4.MoveX(At(Row.Top, Column.Middle));

            after5.OnOngoingOrWonGame(
                ongoing => throw new XunitException(),
                won =>
                {
                    Assert.Equal(Player.X, won.Winner);
                    Assert.True(won.HasEnded);
                });
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

            after5.OnOngoingOrWonGame(
                ongoing =>
                {
                    Assert.False(ongoing.HasEnded);
                    return null;
                }, 
                won => { AssertFail(); });
        }

        [Fact]
        public void MinimalGameWhereOWins()
        {
            // OOO
            // .X.
            // .XX
            var game = new NewGame();
            var after1 = game.MoveX(At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Bottom, Column.Middle));
            var after4 = after3.MoveO(At(Row.Top, Column.Middle));
            var after5 = after4.MoveX(At(Row.Bottom, Column.Right));

            var after6 = after5.OnOngoingOrWonGame(
                ongoing => ongoing.MoveO(At(Row.Top, Column.Right)),
                won => AssertFail());

            after6.OnOngoingOrWonGame(
                ongoing => throw new XunitException(),
                won =>
                {
                    Assert.Equal(Player.O, won.Winner);
                    Assert.True(won.HasEnded);
                });
        }

        [Fact]
        public void Draw()
        {
            // OOX
            // XXO
            // OXX
            var game = new NewGame();
            var after1 = game.MoveX(  At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Top, Column.Right));
            var after4 = after3.MoveO(At(Row.Top, Column.Middle));
            var after5 = after4.MoveX(At(Row.Middle, Column.Left));
            var after6 = after5.OnOngoingOrWonGame(
                ongoing => ongoing.MoveO(At(Row.Middle, Column.Right)),
                won => AssertFail());
            var after7 = after6.OnOngoingOrWonGame(
                ongoing => ongoing.MoveX(At(Row.Bottom, Column.Middle)),
                won => AssertFail());
            var after8 = after7.OnOngoingOrWonGame(
                ongoing => ongoing.MoveO(At(Row.Bottom, Column.Left)),
                won => AssertFail());
            var draw = after8.OnOngoingOrWonGame(
                ongoing => ongoing.MoveX(At(Row.Bottom, Column.Right)),
                won => AssertFail());

            draw.OnDrawOrWonGame(
                onDraw => Assert.True(onDraw.HasEnded),
                won => AssertFail());
        }

        [Fact]
        public void WinIsOnlyNotifiedOnce()
        {
            var game = new NewGame();
            var after1 = game.MoveX(At(Row.Middle, Column.Middle));
            var after2 = after1.MoveO(At(Row.Top, Column.Left));
            var after3 = after2.MoveX(At(Row.Bottom, Column.Middle));
            var after4 = after3.MoveO(At(Row.Top, Column.Right));
            var after5 = after4.MoveX(At(Row.Top, Column.Middle));
            var afterWin = after5.OnOngoingOrWonGame(
                ongoing => throw new XunitException(),
                won => Assert.True(won.HasEnded));

            afterWin.OnOngoingOrWonGame(
                ongoing => throw new XunitException(),
                won => throw new XunitException());
        }

        private void AssertFail()
        {
            Assert.True(false);
        }

        private Position At(Row row, Column column)
        {
            return new Position(row, column);
        }
    }
}
