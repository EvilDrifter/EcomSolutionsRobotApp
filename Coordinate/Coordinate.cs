namespace Coordinate
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set;  }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void IncrementX()
        {
            X++;
        }

        public void DecrementX()
        {
            X--;
        }

        public void IncrementY()
        {  
            Y++;
        }

        public void DecrementY()
        {
            Y--;
        }
    }
}
