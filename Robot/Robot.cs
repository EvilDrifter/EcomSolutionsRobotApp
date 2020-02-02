using System;
using System.Collections.Generic;
using Coordinate;
using Enums;

namespace Robot
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Orientation Orientation { get; private set; }
        public bool IsLost { get; private set; }
        private readonly Planet.Planet _planet;

        public Robot(Position startPosition, Planet.Planet planet)
        {
            this.X = startPosition.Coordinate.X;
            this.Y = startPosition.Coordinate.Y;
            this.Orientation = startPosition.Orientation;
            this._planet = planet;
        }

        public void RunCommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                ExecuteCommand(command);
                if (IsLost) break;
            }
        }

        public void ExecuteCommand(Command command)
        {
            if (!IsLost)
            {
                switch (command)
                {
                    case Command.Forward:
                        CautiouslyMoveFoward();
                        break;
                    case Command.Right:
                        RotateClockwise();
                        break;
                    case Command.Left:
                        RotateCounterclockwise();
                        break;
                    default:
                        throw new ArgumentException($"Command {command} not recognized");
                }
            }
        }

        private void CautiouslyMoveFoward()
        {
            var nextPosition = NextPositionIfMovedForward();

            if (_planet.IsOutOfBounds(nextPosition.X, nextPosition.Y))
            {
                if (!_planet.IsScented(X, Y))
                {
                    IsLost = true;
                    _planet.AddScentedCoordinate(X, Y);
                }
            }
            else
            {
                X = nextPosition.X;
                Y = nextPosition.Y;
            }
        }

        private void RotateClockwise()
        {
            if (Orientation == Orientation.West)
                Orientation = Orientation.North;
            else
                Orientation++;
        }

        private void RotateCounterclockwise()
        {
            if (Orientation == Orientation.North)
                Orientation = Orientation.West;
            else
                Orientation--;
        }

        private Coordinate.Coordinate NextPositionIfMovedForward()
        {
            var nextPosition = new Coordinate.Coordinate(X, Y);

            if (Orientation == Orientation.North)
                nextPosition.IncrementY();
            else if (Orientation == Orientation.East)
                nextPosition.IncrementX();
            else if (Orientation == Orientation.South)
                nextPosition.DecrementY();
            else if (Orientation == Orientation.West)
                nextPosition.DecrementX();

            return nextPosition;
        }
    }
}
