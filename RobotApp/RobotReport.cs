using System.Collections.Generic;
using System.Text;

namespace RobotApp
{
    public static class RobotReport
    {
        public static string GetRobotsReport(IEnumerable<Robot.Robot> robots)
        {
            var s = new StringBuilder();

            foreach (var robot in robots)
            {
                var line = $"{robot.X} {robot.Y} {UserInput.Output.GetOrientation(robot.Orientation)}";
                if (robot.IsLost)
                    line += " LOST";
                s.AppendLine(line);
            }

            return s.ToString();
        }
    }
}