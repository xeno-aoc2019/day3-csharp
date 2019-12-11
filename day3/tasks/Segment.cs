using System;
using static tasks.Direction;

namespace tasks
{
    public class Segment
    {
        private Point end1;
        private Point end2;
        private Direction direction;
        private Segment previous;
        private bool isOrigo = false;

        public Segment(String step, Segment previous)
        {
            var direction = DirectionFactory.ToDirection(step.ToCharArray()[0]);
            var distance = int.Parse(step.Substring(1));
            this.previous = previous;
            this.end1 = previous.end2;
            this.end2 = direction switch
            {
                Up => end1.plusY(distance),
                Down => end1.plusY(-distance),
                Left => end1.plusX(-distance),
                Right => end1.plusX(distance)
            };
        }

        private Segment()
        {
            end1 = new Point(0, 0);
            end2 = new Point(0, 0);
            isOrigo = true;
        }

        public static Segment origo()
        {
            return new Segment();
        }

        public bool isHorizontal()
        {
            return direction == Left || direction == Right;
        }

        public bool isVertical()
        {
            return direction == Up || direction == Down;
        }

        public override string ToString()
        {
            return "Segment(" + end1 + "-" + end2 + ")";
        }

        public string PathString()
        {
            if (isOrigo) return "(•)";
            return "Segment(" + end1 + "-" + end2 + ") -> " + previous.PathString();
        }
    }
}