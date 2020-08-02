using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurtleChallange.Application.Ex;
using TurtleChallange.Domain;
using TurtleChallange.Interfaces;
using System;

namespace TurtleChallange.Application
{
    public class GameEngine : IGameEngine
    {
        private readonly IBoardConfigurationProvider _boardConfigurationProvider;
        private readonly IMovesConfigurationProvider _movesConfigurationProvider;
        private readonly IOutputLogger _outputLogger;
        private readonly ICollection<IBoardValidator> _boardValidators;
        private readonly ICollection<IMoveValidator> _moveValidators;

        public GameEngine(
            IBoardConfigurationProvider boardConfigurationProvider,
            IMovesConfigurationProvider movesConfigurationProvider,
            IOutputLogger outputLogger,
            ICollection<IBoardValidator> boardValidators,
            ICollection<IMoveValidator> moveValidators)
        {
            _boardConfigurationProvider = boardConfigurationProvider;
            _movesConfigurationProvider = movesConfigurationProvider;
            _outputLogger = outputLogger;
            _boardValidators = boardValidators;
            _moveValidators = moveValidators;
        }

        public async Task RunGame()
        {
            try
            {
                var boardConfiguration = await _boardConfigurationProvider.GetBoardConfiguration();

                var movesConfiguration = await _movesConfigurationProvider.GetMovesConfiguration();

                if (_boardValidators.Any(x => !x.IsValid(boardConfiguration)))
                {
                    _outputLogger.LogMessage("Board Configuration Invalid");
                    return;
                }

                if (_moveValidators.Any(x => !x.IsValid(movesConfiguration)))
                {
                    _outputLogger.LogMessage("Move Configuration Invalid");
                    return;
                }

                var turtleGame = new TurtleGame(boardConfiguration);

                foreach (var move in movesConfiguration.Moves)
                {
                    turtleGame.Apply(move.ToMoveType());

                    if (turtleGame.HitAMine)
                    {
                        _outputLogger.LogMessage($"Hit a Mine at ({turtleGame.CurrentXPosition},{turtleGame.CurrentYPosition})");
                        break;
                    }

                    if (turtleGame.ReachedEnd)
                    {
                        _outputLogger.LogMessage($"Reached The End at ({turtleGame.CurrentXPosition},{turtleGame.CurrentYPosition})");
                        break;
                    }
                }

                if (!turtleGame.ReachedEnd && !turtleGame.HitAMine)
                    _outputLogger.LogMessage($"No Moves Remaining finished at ({turtleGame.CurrentXPosition},{turtleGame.CurrentYPosition})");
            }
            catch (Exception ex)
            {
                _outputLogger.LogMessage("Error Running Game");
                throw;
            }
        }
    }
}
