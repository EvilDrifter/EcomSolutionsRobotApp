using System;
using Enums;

namespace UserInput
{
    public static class Output
    {
        public static char GetOrientation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return 'N';
                case Orientation.South:
                    return 'S';
                case Orientation.East:
                    return 'E';
                case Orientation.West:
                    return 'W';
                default:
                    throw new ArgumentException($"orientation {orientation} has no defined char equivalent");
            }
        }
    }
}
