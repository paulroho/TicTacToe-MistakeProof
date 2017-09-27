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
                ongoing =>
                {
                    return ongoing.MoveO(At(Row.Top, Column.Right));
                },
                won =>
                {
                    AssertFail();
                });

            after6.OnOngoingOrWonGame(
                ongoing => throw new XunitException(),
                won =>
                {
                    Assert.Equal(Player.O, won.Winner);
                    Assert.True(won.HasEnded);
                });
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

    public class NewGame
    {
        public GameAfterOneMove MoveX(Position position)
        {
            // TODO capture position
            return new GameAfterOneMove();
        }
    }

    public class GameAfterOneMove
    {
        public GameAfterSecondMove MoveO(Position position)
        {
            // TODO capture position
            return new GameAfterSecondMove();
        }
    }

    public class GameAfterSecondMove
    {
        public GameAfterThirdMove MoveX(Position position)
        {
            // TODO capture position
            return new GameAfterThirdMove();
        }
    }

    public class GameAfterThirdMove
    {
        public GameAfterFourthMove MoveO(Position position)
        {
            // TODO capture position
            return new GameAfterFourthMove();
        }
    }

    public class GameAfterFourthMove
    {
        public bool HasEnded => false;

        public GameAfterFifthMoveOrWonGame MoveX(Position position)
        {
            // TODO check for winner
            if (position.Equals(new Position(Row.Top, Column.Middle)))
            {
                return GameAfterFifthMoveOrWonGame.WonGame();
            }
            // TODO capture position
            return GameAfterFifthMoveOrWonGame.GameAfterFifthMove();
        }
    }

    public class GameAfterFifthMove
    {
        public bool HasEnded => false;

        public GameAfterSixthMoveOrWonGame MoveO(Position position)
        {
            // TODO same as in GameAfterFourthMove
            return GameAfterSixthMoveOrWonGame.WonGame();
        }
    }

    public class GameAfterSixthMove
    {
        public bool HasEnded => false;

    }

    public class GameAfterFifthMoveOrWonGame
    {
        // complete
        // TODO mayme make generic in GameAfterFifthMove
        private readonly GameAfterFifthMove _ongoingGame;
        private readonly WonGame _wonGame;

        public static GameAfterFifthMoveOrWonGame GameAfterFifthMove()
        {
            return new GameAfterFifthMoveOrWonGame(new GameAfterFifthMove());
        }

        public static GameAfterFifthMoveOrWonGame WonGame()
        {
            return new GameAfterFifthMoveOrWonGame(new WonGame(Player.X));
        }

        private GameAfterFifthMoveOrWonGame(GameAfterFifthMove gameAfterFifthMove)
        {
            _ongoingGame = gameAfterFifthMove ?? throw new ArgumentNullException(nameof(gameAfterFifthMove));
        }

        private GameAfterFifthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public GameAfterSixthMoveOrWonGame OnOngoingOrWonGame(Func<GameAfterFifthMove, GameAfterSixthMoveOrWonGame> ongoingAction, Action<WonGame> wonAction)
        {
            // TODO check arguments not null
            if (_wonGame != null)
            {
                wonAction(_wonGame);
                return new GameAfterSixthMoveOrWonGame(_wonGame);
            }
            return ongoingAction(_ongoingGame);
        }
    }

    public class GameAfterSixthMoveOrWonGame
    {
        private readonly WonGame _wonGame;

        public static GameAfterSixthMoveOrWonGame WonGame()
        {
            return new GameAfterSixthMoveOrWonGame(new WonGame(Player.O));
        }

        public GameAfterSixthMoveOrWonGame(WonGame wonGame)
        {
            _wonGame = wonGame ?? throw new ArgumentNullException(nameof(wonGame));
        }

        public void OnOngoingOrWonGame(Action<GameAfterSixthMove> ongoingAction, Action<WonGame> wonAction)
        {
            if (_wonGame != null)
            {
                wonAction(_wonGame);
                //return new GameAfterSixthMoveOrWonGame(_wonGame);
            }
            //return ongoingAction(_ongoingGame);
        }

    }

    public class WonGame
    {
        // TODO capture previous state for queries, else complete

        public WonGame(Player winner)
        {
            Winner = winner;
        }

        public Player Winner { get; }

        public bool HasEnded
        {
            get { return true;  }
        }
    }

}
