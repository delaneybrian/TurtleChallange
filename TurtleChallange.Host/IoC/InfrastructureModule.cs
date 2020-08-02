using Autofac;
using TurtleChallange.Infrastructure;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Host.IoC
{
    internal class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FileBoardConfigurationProvider>()
                .WithParameter("fileLocation", @"data/game-settings.json")
                .As<IBoardConfigurationProvider>()
                .SingleInstance();

            builder
               .RegisterType<FileMoveConfigurationProvider>()
               .WithParameter("fileLocation", @"data/moves.json")
               .As<IMovesConfigurationProvider>()
               .SingleInstance();

            builder
               .RegisterType<ConsoleOutputLogger>()
               .As<IOutputLogger>()
               .SingleInstance();
        }
    }
}
