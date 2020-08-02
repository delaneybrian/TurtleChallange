using NUnit.Framework;
using TurtleChallange.Application.Validators;
using TurtleChallange.Definitions;

namespace TutleChallange.UnitTests
{
    [TestFixture]
    public class BoardSizeValidatorTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void BoardOverMaxSize() =>
            _context
                .SetBoardSize(1000)
                .Validate()
                .AssertNotValid();

        [Test]
        public void BoardUnderMinSize() =>
           _context
               .SetBoardSize(2)
               .Validate()
               .AssertNotValid();

        [Test]
        public void BoardSizeValid() =>
           _context
               .SetBoardSize(5)
               .Validate()
               .AssertIsValid();

        public class TestContext
        {
            private BoardSizeValidator _sut = new BoardSizeValidator();

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
