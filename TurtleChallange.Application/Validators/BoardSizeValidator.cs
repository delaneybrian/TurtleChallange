using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Application.Validators
{
    public class BoardSizeValidator : IBoardValidator
    {
        private const int MinBoardSize = 3;
        private const int MaxBoardSize = 100;

        public bool IsValid(BoardConfiguration boardConfiguration)
        {
            return boardConfiguration.Size < MaxBoardSize &&
                   boardConfiguration.Size > MinBoardSize;
        }
    }
}
