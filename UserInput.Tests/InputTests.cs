using Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserInput.Tests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void GetCoordinates_ValidInput_CorrectParsing()
        {
            var coordinate = Input.GetCoordinates("5 3");

            Assert.IsNotNull(coordinate);
            Assert.AreEqual(5, coordinate.X);
            Assert.AreEqual(3, coordinate.Y);
        }

        [TestMethod]
        public void GetCoordinates_InValidInput_null()
        {
            var coordinate = Input.GetCoordinates("5");

            Assert.IsNull(coordinate);
        }

        [TestMethod]
        public void GetCoordinates_TooManyInput_CorrectParsing()
        {
            var coordinate = Input.GetCoordinates("5 4 5");

            Assert.IsNull(coordinate);
        }

        [TestMethod]
        public void GetPosition_ValidInput_CorrectParsing()
        {
            var position = Input.GetPosition("03 W");

            Assert.IsNotNull(position);
            Assert.AreEqual(0, position.Coordinate.X);
            Assert.AreEqual(3, position.Coordinate.Y);
            Assert.AreEqual(Orientation.West, position.Orientation);
        }

        [TestMethod]
        public void GetPosition_InValidInput_CorrectParsing()
        {
            var position = Input.GetCoordinates("554");

            Assert.IsNull(position);
        }

        [TestMethod]
        public void GetPosition_InValidOrientation_CorrectParsing()
        {
            var position = Input.GetCoordinates("55 X");

            Assert.IsNull(position);
        }
    }
}
