using System;
using System.Linq;
using System.Reflection;
using Autofac;
using TurtleChallange.Application;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Host.IoC
{
    internal class ApplicationModule : Autofac.Module
    {
        private static readonly Assembly ApplicationAssembly = GetAssemblyFor("TurtleChallange.Application");

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<GameEngine>()
                .As<IGameEngine>();

            builder
                .RegisterAssemblyTypes(ApplicationAssembly)
                .Where(t => typeof(IBoardValidator).IsAssignableFrom(t))
                .As<IBoardValidator>();

            builder
                .RegisterAssemblyTypes(ApplicationAssembly)
                .Where(t => typeof(IMoveValidator).IsAssignableFrom(t))
                .As<IMoveValidator>();
        }

    private static Assembly GetAssemblyFor(string s)
    {
        var assembly = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SingleOrDefault(x => x.GetName().Name == s);

        return assembly ?? Assembly.Load(s);
    }
}
}
