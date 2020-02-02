using System.Collections.Generic;
using Enums;

namespace RobotApp
{
    public class CommandStation
    {
        public List<Robot.Robot> Robots { get; private set; }

        public CommandStation(List<Robot.Robot> robots)
        {
            Robots = robots;
        }

        public void TransmitCommandSequence(int robotIndex, List<Command> commandSequence)
        {
            foreach (var command in commandSequence)
                Robots[robotIndex].ExecuteCommand(command);
        }
    }
}