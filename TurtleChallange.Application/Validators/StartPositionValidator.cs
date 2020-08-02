using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Application.Validators
{
    public class StartPositionValidator : IBoardValidator
    {
        public bool IsValid(BoardConfiguration boardConfiguration)
        {
            if(boardConfiguration.StartPosition == null)
                return true;

            if (boardConfiguration.StartPosition.XCoordinate > (boardConfiguration.Size - 1) ||
                boardConfiguration.StartPosition.YCoordinate > (boardConfiguration.Size - 1))
                return false;

            if (boardConfiguration.StartPosition.XCoordinate < 0 ||
                boardConfiguration.StartPosition.YCoordinate < 0)
                return false;

            if (boardConfiguration.EndPosition == null &&
                boardConfiguration.StartPosition.XCoordinate == 0 &&
                boardConfiguration.StartPosition.YCoordinate == 0)
                return false;

            if (boardConfiguration.EndPosition.XCoordinate == boardConfiguration.StartPosition.XCoordinate &&
                boardConfiguration.EndPosition.YCoordinate == boardConfiguration.StartPosition.YCoordinate)
                return false;

            return true;
        }
    }
}
