using Autofac;
using System.Linq;
using TurtleChallange.Host.IoC;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var container = Bootstrapper.Bootstrap())
            {
                var gameEngine = container.Resolve<IGameEngine>();

                gameEngine.RunGame();
            }
        }
    }
}
