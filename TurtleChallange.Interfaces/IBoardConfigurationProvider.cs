using System;
using System.Threading.Tasks;
using TurtleChallange.Definitions;

namespace TurtleChallange.Interfaces
{
    public interface IBoardConfigurationProvider
    {
        Task<BoardConfiguration> GetBoardConfiguration();
    }
}
