using System;
using System.Collections.Generic;
using static tasks.Direction;

namespace tasks
{
    public class Segment
    {
        private Point end1;
        private Point end2;
        private Direction direction;
        private int distance;
        private Segment previous;
        private bool isOrigo = false;
        private int cost;
        private bool reverse = false;

        public Segment(string step, Segment previous)
        {
            direction = DirectionFactory.ToDirection(step.ToCharArray()[0]);
            distance = int.Parse(step.Substring(1));
            this.previous = previous;
            this.end1 = previous.end2;
            this.end2 = direction switch
            {
                Up => end1.plusY(distance),
                Down => end1.plusY(-distance),
                Left => end1.plusX(-distance),
                Right => end1.plusX(distance),
                _ => throw new Exception("Goodbye cruel world")
            };
            this.cost = previous.cost + previous.distance;
        }

        private Segment()
        {
            end1 = new Point(0, 0);
            end2 = new Point(0, 0);
            cost = 0;
            distance = 0;
            isOrigo = true;
        }

        private Segment(Segment other, Segment previous, bool reverse)
        {
            this.reverse = reverse;
            this.end1 = reverse ? other.end2 : other.end1;
            this.end2 = reverse ? other.end1 : other.end2;
            this.direction = other.direction;
            this.previous = previous;
            this.isOrigo = other.isOrigo;
            this.cost = other.cost;
            this.distance = other.distance;
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
            return "Segment(" + end1 + "-" + end2 + " " + direction + ")";
        }


        public string PathString()
        {
            if (isOrigo) return "(•)";
            return "Segment((" + end1.X + "," + end1.Y + ")-(" + end2.X + "," + end2.Y + "):" + cost + " " + direction +
                   ") -> " + previous.PathString();
        }

        public LinkedList<Segment> horizontals()
        {
            if (isOrigo) return new LinkedList<Segment>();
            var horiz = previous.horizontals();
            if (isHorizontal())
            {
                horiz.AddFirst(this);
            }

            return horiz;
        }

        public LinkedList<Segment> verticals()
        {
            if (isOrigo) return new LinkedList<Segment>();
            var horiz = previous.horizontals();
            if (isVertical())
            {
                horiz.AddFirst(this);
            }

            return horiz;
        }

        public List<Segment> ToList()
        {
            return ToBackwardList();
        }

        public List<Segment> ToForwardList()
        {
            var list = ToBackwardList();
            list.Reverse();
            return list;
        }

        public List<Segment> ToBackwardList()
        {
            var list = new List<Segment> {this};
            var prev = previous;
            while (!prev.isOrigo)
            {
                list.Add(prev);
                prev = prev.previous;
            }

            return list;
        }

        public Segment Normalize()
        {
            if (isOrigo) return this;
            var reverse = end1.X > end2.X || end1.Y > end2.Y;
            return new Segment(this, previous.Normalize(), reverse);
        }

        public Point End1 => end1;

        public Point End2 => end2;

        public int Distance => distance;

        public int Cost(Point p)
        {
            if (isHorizontal())
            {
                var localCost = reverse ? Math.Abs(end2.X - p.X) : Math.Abs(p.X - end1.X);
                if (localCost < 1) Console.WriteLine("LocalCost: " + localCost);
                return cost + localCost;
            }
            else
            {
                var localCost = reverse ? Math.Abs(end2.Y - p.Y) : Math.Abs(p.Y - end1.Y);
                if (localCost < 1) Console.WriteLine("LocalCost: " + localCost);
                return cost + localCost;
            }
        }
    }
}