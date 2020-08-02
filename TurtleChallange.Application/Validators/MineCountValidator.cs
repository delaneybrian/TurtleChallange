using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Application.Validators
{
    public class MineCountValidator : IBoardValidator
    {
        private readonly int MinMineThreshold = 3;
        private readonly int MaxMineThreshold = 8;

        public bool IsValid(BoardConfiguration boardConfiguration)
        {
            var avaibableSpaces = boardConfiguration.Size * boardConfiguration.Size;

            var mineRatio = avaibableSpaces / boardConfiguration.MineCount;

            if (mineRatio > MaxMineThreshold)
                return false;

            if (mineRatio < MinMineThreshold)
                return false;

            return true;
        }
    }
}
