using System.Collections.Generic;
using System.Linq;
using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Application.Validators
{
    public class MoveStringValidator : IMoveValidator
    {
        private readonly ICollection<string> ValidMoves = new List<string>
        {
            "L",
            "LEFT",
            "R",
            "RIGHT",
            "U",
            "UP",
            "D",
            "DOWN",
        };

        public bool IsValid(MovesConfiguration movesConfiguration)
        {
            return movesConfiguration
                .Moves
                .All(x => ValidMoves.Contains(x.ToUpperInvariant()));
        }
    }
}
