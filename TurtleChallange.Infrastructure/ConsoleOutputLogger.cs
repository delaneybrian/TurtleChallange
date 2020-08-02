using System;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Infrastructure
{
    public class ConsoleOutputLogger : IOutputLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
