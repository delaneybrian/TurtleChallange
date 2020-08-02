using NUnit.Framework;
using TurtleChallange.Definitions;
using TurtleChallange.Domain;

namespace TutleChallange.UnitTests
{
    [TestFixture]
    public class TurtleGameTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void ReachedEndWithNoMines() =>
            _context
                .AddBoardSize(3)
                .AddStartPosition(0, 0)
                .AddEndPosition(2, 2)
                .AddMineCount(0)
                .CreateGame()
                .ApplyMove(Move.Up)
                .ApplyMove(Move.Up)
                .ApplyMove(Move.Up)
                .ApplyMove(Move.Right)
                .ApplyMove(Move.Right)
                .ApplyMove(Move.Right)
                .AssertReachedEnd()
                .AssertNotHitAMine();

        [Test]
        public void HitMineWithAllMines() =>
              _context
                  .AddBoardSize(3)
                  .AddStartPosition(0, 0)
                  .AddEndPosition(2, 2)
                  .AddMineCount(7)
                  .CreateGame()
                  .ApplyMove(Move.Up)
                  .ApplyMove(Move.Up)
                  .ApplyMove(Move.Up)
                  .ApplyMove(Move.Right)
                  .ApplyMove(Move.Right)
                  .ApplyMove(Move.Right)
                  .AssertHitAMine();

        [Test]
        public void NotHitMineOrReachedEnd() =>
            _context
                .AddBoardSize(3)
                .AddStartPosition(0, 0)
                .AddEndPosition(2, 2)
                .AddMineCount(0)
                .CreateGame()
                .ApplyMove(Move.Up)
                .ApplyMove(Move.Right)
                .AssertNotHitAMine()
                .AssertNotReachedEnd();

        public class TestContext
        {
            private TurtleGame _sut;

            private BoardConfiguration _boardConfiguration =
                new BoardConfiguration();

            public TestContext AddBoardSize(int size)
            {
                _boardConfiguration.Size = size;

                return this;
            }

            public TestContext AddStartPosition(int startXCoordinate, int startYCoordinate)
            {
                _boardConfiguration.StartPosition = new CoordinatePosition
                {
                    XCoordinate = startXCoordinate,
                    YCoordinate = startXCoordinate
                };

                return this;
            }

            public TestContext AddEndPosition(int endXCoordinate, int endYCoordinate)
            {
                _boardConfiguration.EndPosition = new CoordinatePosition
                {
                    XCoordinate = endXCoordinate,
                    YCoordinate = endYCoordinate
                };

                return this;
            }

            public TestContext AddMineCount(int mineCount)
            {
                _boardConfiguration.MineCount = mineCount;

                return this;
            }

            public TestContext CreateGame()
            {
                _sut = new TurtleGame(_boardConfiguration);

                return this;
            }

            public TestContext ApplyMove(Move move)
            {
                _sut.Apply(move);

                return this;
            }

            public TestContext AssertNotReachedEnd()
            {
                Assert.IsFalse(_sut.ReachedEnd);

                return this;
            }

            public TestContext AssertNotHitAMine()
            {
                Assert.IsFalse(_sut.HitAMine);

                return this;
            }

            public TestContext AssertReachedEnd()
            {
                Assert.IsTrue(_sut.ReachedEnd);

                return this;
            }

            public TestContext AssertHitAMine()
            {
                Assert.IsTrue(_sut.HitAMine);

                return this;
            }
        }
    }
}
