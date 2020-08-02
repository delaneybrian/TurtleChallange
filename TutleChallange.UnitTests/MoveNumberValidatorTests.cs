using NUnit.Framework;
using TurtleChallange.Application.Validators;
using TurtleChallange.Definitions;

namespace TutleChallange.UnitTests
{
    [TestFixture]
    public class MoveNumberValidatorTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void NumberOfMovesTooLow() =>
            _context
                .AddMove("R")
                .AddMove("L")
                .Validate()
                .AssertNotValid();

        [Test]
        public void NumberOfMovesValid() =>
              _context
                  .AddMove("R")
                  .AddMove("L")
                  .AddMove("R")
                  .AddMove("L")
                  .AddMove("R")
                  .AddMove("L")
                  .AddMove("R")
                  .AddMove("L")
                  .AddMove("R")
                  .AddMove("L")
                  .AddMove("U")
                  .Validate()
                  .AssertIsValid();

        public class TestContext
        {
            private MoveNumberValidator _sut = new MoveNumberValidator();

            private MovesConfiguration _movesConfiguration = new MovesConfiguration();

            private bool _valid;

            public TestContext AddMove(string move)
            {
                _movesConfiguration.Moves.Add(move);

                return this;
            }

            public TestContext Validate()
            {
                _valid = _sut.IsValid(_movesConfiguration);

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
