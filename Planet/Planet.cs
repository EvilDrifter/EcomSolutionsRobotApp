using System.Collections.Generic;

namespace Planet
{
    public class Planet
    {
        public int XBound { get; }
        public int YBound { get; }
        private readonly List<Coordinate.Coordinate> _scentedCoordinates = new List<Coordinate.Coordinate>();

        public Planet(int xBound, int yBound)
        {
            XBound = xBound;
            YBound = yBound;
        }

        public void AddScentedCoordinate(int x, int y)
        {
            _scentedCoordinates.Add(new Coordinate.Coordinate(x, y));
        }

        public bool IsScented(int x, int y)
        {
            return _scentedCoordinates.Contains(new Coordinate.Coordinate(x, y));
        }

        public bool IsOutOfBounds(int x, int y)
        {
            return x > XBound || x < 0 || y > YBound || y < 0;
        }
    }
}
