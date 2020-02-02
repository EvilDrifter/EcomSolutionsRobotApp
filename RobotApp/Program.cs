using System.Collections.Generic;
using UserInput;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinatesForMars = Input.GetCoordinates("5 3");
            var mars = new Planet.Planet(coordinatesForMars.X, coordinatesForMars.Y);

            var robotPosition = Input.GetPosition("1 1 E");
            var robotCommand = Input.GetCommands("RFRFRFRF");
            var robot = new Robot.Robot(robotPosition, mars);

            robot.RunCommands(robotCommand);


            var robotPosition2 = Input.GetPosition("3 2 N");
            var robotCommand2 = Input.GetCommands("FRRFLLFFRRFLL");
            var robot2 = new Robot.Robot(robotPosition2, mars);

            robot2.RunCommands(robotCommand2);


            var robotPosition3 = Input.GetPosition("03 W");
            var robotCommand3 = Input.GetCommands("LLFFFLFLFL");
            var robot3 = new Robot.Robot(robotPosition3, mars);

            robot3.RunCommands(robotCommand3);


            var robotReport = RobotReport.GetRobotsReport(new List<Robot.Robot> {robot, robot2, robot3});
        }
    }
}
