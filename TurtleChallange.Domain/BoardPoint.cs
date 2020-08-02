namespace TurtleChallange.Domain
{
    public class BoardPoint
    {
        public int XCoordinate { get; private set; }

        public int YCoordinate { get; private set; }

        public bool HasMine { get; private set; }

        public BoardPoint(
            int xCoordinate,
            int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public void PlaceMine()
        {
            HasMine = true;
        }
    }
}
