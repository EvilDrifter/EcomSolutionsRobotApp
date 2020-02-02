using System.Collections.Generic;
using System.Linq;
using Coordinate;
using Enums;

namespace UserInput
{
    public static class Input
    {
        public static Coordinate.Coordinate GetCoordinates(string userInput)
        {
            var input = GetUserInputWithoutSpaces(userInput).ToList();

            if (input.Count == 2)
            {
                if (int.TryParse(input[0].ToString(), out var coordinateX) &&
                    int.TryParse(input[1].ToString(), out var coordinateY))
                {
                    return new Coordinate.Coordinate(coordinateX, coordinateY);
                }

                
            }

            return null;
        }

        public static Position GetPosition(string userInput)
        {
            var input = GetUserInputWithoutSpaces(userInput).ToList();

            if (input.Count == 3)
            {
                var orientation = GetOrientation(input[2], out var success);
                if (int.TryParse(input[0].ToString(), out var coordinateX) && int.TryParse(input[1].ToString(), out var coordinateY) && success)
                {
                    return new Position(new Coordinate.Coordinate(coordinateX, coordinateY), orientation);
                }


            }

            return null;
        }

        public static IEnumerable<Command> GetCommands(string userInput)
        {
            var input = GetUserInputWithoutSpaces(userInput).ToList();
            var result = new List<Command>();

            foreach (var oneInput in input)
            {
                var c = GetCommand(oneInput, out var success);
                if (success)
                {
                    result.Add(c);
                }
                else
                {
                    return null;
                }
            }

            return result;
        }


        private static IEnumerable<char> GetUserInputWithoutSpaces(string userInput)
        {
            return userInput.Replace(" ", string.Empty).ToCharArray();
        }


        private static Command GetCommand(char command, out bool success)
        {
            success = true;
            switch (char.ToUpper(command))
            {
                case 'F':
                    return Command.Forward;
                case 'R':
                    return Command.Right;
                case 'L':
                    return Command.Left;
                default:
                    success = false;
                    return Command.Forward;
            }
        }

        private static Orientation GetOrientation(char orientation, out bool success)
        {
            success = true;
            switch (char.ToUpper(orientation))
            {
                case 'N':
                    return Orientation.North;
                case 'E':
                    return Orientation.East;
                case 'S':
                    return Orientation.South;
                case 'W':
                    return Orientation.West;
                default:
                    success = false;
                    return Orientation.North;
            }
        }
    }
}
