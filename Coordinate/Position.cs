using Enums;

namespace Coordinate
{
    public class Position
    {
        public Coordinate Coordinate { get; }

        public Orientation Orientation { get; }

        public Position(Coordinate coordinate, Orientation orientation)
        {
            this.Coordinate = coordinate;
            this.Orientation = orientation;
        }
    }
}