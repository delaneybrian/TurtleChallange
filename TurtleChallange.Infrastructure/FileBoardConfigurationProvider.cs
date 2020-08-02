using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TurtleChallange.Definitions;
using TurtleChallange.Interfaces;

namespace TurtleChallange.Infrastructure
{
    public class FileBoardConfigurationProvider : IBoardConfigurationProvider
    {
        private readonly string _fileLocation;
        private readonly IOutputLogger _outputLogger;

        public FileBoardConfigurationProvider(
            string fileLocation,
            IOutputLogger outputLogger)
        {
            _fileLocation = fileLocation;
            _outputLogger = outputLogger;
        }

        public async Task<BoardConfiguration> GetBoardConfiguration()
        {
            try
            {
                var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var fullFilePath = Path.Combine(directoryPath, _fileLocation);

                var text = await File.ReadAllTextAsync(fullFilePath);

                return JsonConvert.DeserializeObject<BoardConfiguration>(text);            
            }
            catch (Exception ex)
            {
                _outputLogger.LogMessage("Error Reading Board Configuration File");
                throw;
            }     
        }
    }
}
