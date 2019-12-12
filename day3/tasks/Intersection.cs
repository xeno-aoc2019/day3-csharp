namespace tasks
{
    public class Intersection
    {
        private Point point;
        private int cost;

        public Intersection(Point point, int cost)
        {
            this.point = point;
            this.cost = cost == 0 ? int.MaxValue : cost;
        }

        public Intersection(int x, int y, int cost)
        {
            this.point = new Point(x, y);
            this.cost = cost == 0 ? int.MaxValue : cost;
        }

        // public Intersection(int x, int y)
        // {
        //     this.point = new Point(x, y);
        //     this.cost = -1;
        // }

        public Point Point => point;

        public int Cost => cost;

        public override string ToString()
        {
            return "Intersection(" + point.X + "," + point.Y + " cost=" + cost + ")";
        }

        public int ManhattanDistance()
        {
            if (point.X == 0 && point.Y == 0)
            {
                return int.MaxValue;
            }

            return point.X + point.Y;
        }
    }
}