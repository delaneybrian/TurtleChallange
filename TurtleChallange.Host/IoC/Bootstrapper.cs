using Autofac;

namespace TurtleChallange.Host.IoC
{
    internal static class Bootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new ApplicationModule());

            return builder.Build();
        }
    }
}
