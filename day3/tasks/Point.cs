namespace tasks
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X => x;
        public int Y => y;

        public Point plusX(int x)
        {
            return new Point(this.x + x, y);
        }

        public Point plusY(int y)
        {
            return new Point(this.x, this.y + y);
        }

        public override string ToString()
        {
            return "Point(" + x + "," + y + ")";
        }
    }
}