using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallange.Definitions;

namespace TurtleChallange.Domain
{
    public class TurtleGame
    {
        public bool HitAMine { get; private set; }

        public int CurrentXPosition { get; private set; }

        public int CurrentYPosition { get; private set; }

        public bool ReachedEnd => CurrentXPosition == EndXPosition &&
            CurrentYPosition == EndYPosition;

        private ICollection<BoardPoint> Board { get; set; } 

        private int BoardSize { get; set; }

        private int StartXPosition { get; set; }

        private int StartYPosition { get; set; }

        private int EndXPosition { get; set; }

        private int EndYPosition { get; set; }

        public TurtleGame(BoardConfiguration boardConfiguration)
        {        
            InitalizeBoard(
                boardConfiguration.Size, 
                boardConfiguration.StartPosition, 
                boardConfiguration.EndPosition);

            AddMines(boardConfiguration.MineCount);
        }

        public void Apply(Move move)
        {
            switch(move)
            {
                case (Move.Down):
                    TryMoveDown();
                    break;
                case (Move.Up):
                    TryMoveUp();
                    break;
                case (Move.Right):
                    TryMoveRight();
                    break;
                case (Move.Left):
                    TryMoveLeft();
                    break;
                default:
                    throw new ArgumentException("To Fill in");
            };
        }

        private void TryMoveDown()
        {
            if (CurrentYPosition == 0)
                return;

            CurrentYPosition = CurrentYPosition - 1;

            var newPosition = Board.Single(bp => bp.XCoordinate == CurrentXPosition &&
                                                 bp.YCoordinate == CurrentYPosition);

            if (newPosition.HasMine)
                HitAMine = true;
        }

        private void TryMoveUp()
        {
            if (CurrentYPosition == (BoardSize - 1))
                return;

            CurrentYPosition = CurrentYPosition + 1;

            var newPosition = Board.Single(bp => bp.XCoordinate == CurrentXPosition &&
                                                bp.YCoordinate == CurrentYPosition);

            if (newPosition.HasMine)
                HitAMine = true;
        }

        private void TryMoveRight()
        {
            if (CurrentXPosition == (BoardSize - 1))
                return;

            CurrentXPosition = CurrentXPosition + 1;

            var newPosition = Board.Single(bp => bp.XCoordinate == CurrentXPosition &&
                                               bp.YCoordinate == CurrentYPosition);

            if (newPosition.HasMine)
                HitAMine = true;
        }

        private void TryMoveLeft()
        {
            if (CurrentXPosition == 0)
                return;

            CurrentXPosition = CurrentXPosition - 1;

            var newPosition = Board.Single(bp => bp.XCoordinate == CurrentXPosition &&
                                               bp.YCoordinate == CurrentYPosition);

            if (newPosition.HasMine)
                HitAMine = true;
        }

        private void InitalizeBoard(
            int boardSize,
            CoordinatePosition startPosition,
            CoordinatePosition endPosition)
        {
            if(startPosition != null)
            {
                CurrentXPosition = startPosition.XCoordinate;
                CurrentYPosition = startPosition.YCoordinate;
            }
            else
            {
                CurrentXPosition = 0;
                CurrentYPosition = 0;
            }        

            Board = new List<BoardPoint>();
            BoardSize = boardSize;

            if (endPosition != null)
            {
                EndXPosition = endPosition.XCoordinate;
                EndYPosition = endPosition.YCoordinate;
            }
            else
            {
                EndXPosition = BoardSize - 1;
                EndYPosition = BoardSize - 1;
            }

            for (int xCoordinate = 0; xCoordinate < boardSize; xCoordinate++)
            {
                for (int yCoordinate = 0; yCoordinate < boardSize; yCoordinate++)
                {
                    Board.Add(new BoardPoint(xCoordinate, yCoordinate));
                }
            }
        }

        private void AddMines(int mineCount)
        {
            var rand = new Random();

            for (var mineNum = 0; mineNum < mineCount; mineNum++)
            {
                var minePlaced = false;
                while (!minePlaced)
                {
                    var MineXCoordinate = rand.Next(0, BoardSize);
                    var MineYCoordinate = rand.Next(0, BoardSize);

                    var boardPoint = Board.Single(bp => bp.XCoordinate == MineXCoordinate &&
                                                        bp.YCoordinate == MineYCoordinate);

                    if (boardPoint.HasMine ||
                        !IsValidPositionForMine(boardPoint))
                        continue;

                    boardPoint.PlaceMine();
                    minePlaced = true;
                }
            }
        }

        private bool IsValidPositionForMine(BoardPoint boardPoint)
        {
            if (boardPoint.XCoordinate == StartXPosition &&
               boardPoint.YCoordinate == StartYPosition)
                return false;

            if (boardPoint.XCoordinate == EndXPosition &&
              boardPoint.YCoordinate == EndYPosition)
                return false;

            return true;
        }
    }
}
