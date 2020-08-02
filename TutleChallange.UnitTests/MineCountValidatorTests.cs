using NUnit.Framework;
using TurtleChallange.Application.Validators;
using TurtleChallange.Definitions;

namespace TutleChallange.UnitTests
{
    [TestFixture]
    public class MineCountValidatorTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void MinCountTooLowInvalid() =>
             _context
                 .SetBoardSize(5)
                 .SetMineCount(2)
                 .Validate()
                 .AssertNotValid();

        [Test]
        public void MinCountTooHighInvalid() =>
            _context
                .SetBoardSize(5)
                .SetMineCount(10)
                .Validate()
                .AssertNotValid();

        [Test]
        public void MinCountValid() =>
           _context
               .SetBoardSize(5)
               .SetMineCount(3)
               .Validate()
               .AssertIsValid();

        public class TestContext
        {
            private MineCountValidator _sut = new MineCountValidator();

            private BoardConfiguration _boardConfiguration = new BoardConfiguration();

            private bool _valid;

            public TestContext SetBoardSize(int boardSize)
            {
                _boardConfiguration.Size = boardSize;

                return this;
            }

            public TestContext SetMineCount(int mineCount)
            {
                _boardConfiguration.MineCount = mineCount;

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
