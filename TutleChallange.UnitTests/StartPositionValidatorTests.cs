using NUnit.Framework;
using TurtleChallange.Application.Validators;
using TurtleChallange.Definitions;

namespace TutleChallange.UnitTests
{
    [TestFixture]
    public class StartPositionValidatorTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void NegativeXCoordinateStartPositionInvalid() =>
             _context
                .SetBoardSize(5)
                .SetStartPosition(-3, 3)
                .Validate()
                .AssertNotValid();

        [Test]
        public void NegativeYCoordinateStartPositionInvalid() =>
              _context
                  .SetBoardSize(5)
                  .SetStartPosition(3, -3)
                  .Validate()
                  .AssertNotValid();

        [Test]
        public void NegativeStartPositionInvalid() =>
             _context
                 .SetBoardSize(5)
                 .SetStartPosition(-3, -3)
                 .Validate()
                 .AssertNotValid();

        [Test]
        public void LargeXCoordinateStartPositionInvalid() =>
           _context
               .SetBoardSize(5)
               .SetStartPosition(5, 3)
               .Validate()
               .AssertNotValid();

        [Test]
        public void LargeYCoordinateStartPositionInvalid() =>
              _context
                  .SetBoardSize(5)
                  .SetStartPosition(3, 5)
                  .Validate()
                  .AssertNotValid();

        [Test]
        public void LargeStartPositionInvalid() =>
            _context
                .SetBoardSize(5)
                .SetStartPosition(5, 5)
                .Validate()
                .AssertNotValid();

        [Test]
        public void ZeroStartPositionInvalidWithNoEndPosition() =>
          _context
              .SetBoardSize(5)
              .SetStartPosition(0, 0)
              .Validate()
              .AssertNotValid();

        [Test]
        public void SameStartAndEndPositionInvalid() =>
             _context
                 .SetBoardSize(5)
                 .SetEndPosition(1, 1)
                 .SetStartPosition(1, 1)
                 .Validate()
                 .AssertNotValid();

        [Test]
        public void SetEndPositionValid() =>
            _context
                .SetBoardSize(5)
                .SetEndPosition(1, 1)
                .Validate()
                .AssertIsValid();

        [Test]
        public void SetStartAndEndPositionValid() =>
           _context
               .SetBoardSize(5)
               .SetStartPosition(1, 1)
               .SetEndPosition(2, 2)
               .Validate()
               .AssertIsValid();

        public class TestContext
        {
            private StartPositionValidator _sut = new StartPositionValidator();

            private BoardConfiguration _boardConfiguration = new BoardConfiguration();

            private bool _valid;

            public TestContext SetBoardSize(int boardSize)
            {
                _boardConfiguration.Size = boardSize;

                return this;
            }

            public TestContext SetStartPosition(int startXCoordinate, int startYCoordinate)
            {
                _boardConfiguration.StartPosition = new CoordinatePosition
                {
                    XCoordinate = startXCoordinate,
                    YCoordinate = startYCoordinate
                };

                return this;
            }

            public TestContext SetEndPosition(int endXCoordinate, int endYCoordinate)
            {
                _boardConfiguration.EndPosition = new CoordinatePosition
                {
                    XCoordinate = endXCoordinate,
                    YCoordinate = endYCoordinate
                };

                return this;
            }

            public TestContext Validate()
            {
                _valid = _sut.IsValid(_boardConfiguration);

                return this;
            }

            public TestContext AssertIsValid()
            {
                Assert.IsTrue(_valid);

                return this;
            }

            public TestContext AssertNotValid()
            {
                Assert.IsFalse(_valid);

                return this;
            }
        }
    }
}
