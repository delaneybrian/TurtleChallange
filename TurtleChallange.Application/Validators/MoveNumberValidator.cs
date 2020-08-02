using System.Linq;
using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Application.Validators
{
    public class MoveNumberValidator : IMoveValidator
    {
        private const int MinRequiredMoves = 10;

        public bool IsValid(MovesConfiguration movesConfiguration)
        {
            return movesConfiguration
                .Moves
                .Count() >= MinRequiredMoves;
        }
    }
}
