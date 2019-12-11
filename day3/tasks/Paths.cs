namespace tasks
{
    public class Paths
    {
        private Segment path1;
        private Segment path2;

        public Paths(Segment path1, Segment path2)
        {
            this.path1 = path1;
            this.path2 = path2;
        }

        public Segment Path1 => path1;

        public Segment Path2 => path2;
    }
}