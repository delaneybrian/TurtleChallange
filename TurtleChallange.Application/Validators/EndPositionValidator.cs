using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Application.Validators
{
    public class EndPositionValidator : IBoardValidator
    {
        public bool IsValid(BoardConfiguration boardConfiguration)
        {
            if (boardConfiguration.EndPosition == null)
                return true;

            if (boardConfiguration.EndPosition.XCoordinate > (boardConfiguration.Size - 1) ||
                boardConfiguration.EndPosition.YCoordinate > (boardConfiguration.Size - 1))
                return false;

            if (boardConfiguration.EndPosition.XCoordinate < 0 ||
                boardConfiguration.EndPosition.YCoordinate < 0)
                return false;

            if (boardConfiguration.StartPosition == null &&
                boardConfiguration.EndPosition.XCoordinate == 0 &&
                boardConfiguration.EndPosition.YCoordinate == 0)
                return false;

            if (boardConfiguration.StartPosition.XCoordinate == boardConfiguration.EndPosition.XCoordinate &&
                boardConfiguration.StartPosition.YCoordinate == boardConfiguration.EndPosition.YCoordinate)
                return false;

            return true;
        }
    }
}
