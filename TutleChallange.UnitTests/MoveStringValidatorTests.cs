using NUnit.Framework;
using TurtleChallange.Application.Validators;
using TurtleChallange.Definitions;

namespace TutleChallange.UnitTests
{
    [TestFixture]
    public class MoveStringValidatorTests
    {
        public TestContext _context;

        [SetUp]
        public void SetUp() => _context = new TestContext();

        [Test]
        public void AssertLeftIsValid() =>
            _context
                .AddMove("Left")
                .AddMove("LEFT")
                .AddMove("L")
                .AddMove("l")
                .Validate()
                .AssertIsValid();

        [Test]
        public void AssertRightIsValid() =>
          _context
              .AddMove("Right")
              .AddMove("RIGHT")
              .AddMove("R")
              .AddMove("r")
              .Validate()
              .AssertIsValid();

        [Test]
        public void AssertUpIsValid() =>
          _context
              .AddMove("UP")
              .AddMove("up")
              .AddMove("U")
              .AddMove("u")
              .Validate()
              .AssertIsValid();

        [Test]
        public void AssertDownIsValid() =>
          _context
              .AddMove("Down")
              .AddMove("DOWN")
              .AddMove("D")
              .AddMove("d")
              .Validate()
              .AssertIsValid();

        [Test]
        public void AssertOtherStringsInvalid() =>
          _context
              .AddMove("Hello")
              .AddMove("Brian")
              .AddMove("123")
              .AddMove("UpUp")
              .Validate()
              .AssertNotValid();

        public class TestContext
        {
            private MoveStringValidator _sut = new MoveStringValidator();

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
