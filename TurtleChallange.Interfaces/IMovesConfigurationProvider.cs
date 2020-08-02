using System.Threading.Tasks;
using TurtleChallange.Definitions;

namespace TurtleChallange.Interfaces
{
    public interface IMovesConfigurationProvider
    {
        Task<MovesConfiguration> GetMovesConfiguration();
    }
}
