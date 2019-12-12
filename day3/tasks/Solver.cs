using System;
using System.Collections.Generic;
using System.Numerics;

namespace tasks
{
    public class Solver
    {
        private static List<Intersection> FindIntersects(Segment s1, Segment s2)
        {
            var intersects = new List<Intersection>();
            if (s1.isHorizontal())
            {
                if (s2.isHorizontal())
                {
                    if (s1.End1.Y == s2.End1.Y)
                    {
                        var leftMost = Math.Max(s1.End1.X, s2.End1.X);
                        var rightMost = Math.Min(s1.End2.X, s2.End2.X);
                        if (leftMost <= rightMost)
                        {
                            intersects.Add(Intersection(leftMost, s2.End1.Y, s1, s2));
                            intersects.Add(Intersection(rightMost, s2.End1.Y, s1, s2));
                        }
                    }
                }
                else
                {
                    if (Utils.InInterval(s2.End1.X, s1.End1.X, s1.End2.X) &&
                        Utils.InInterval(s1.End1.Y, s2.End1.Y, s2.End2.Y))
                    {
                        intersects.Add(Intersection(s2.End1.X, s1.End1.Y, s1, s2));
                    }
                }
            }
            else
            {
                if (s2.isVertical())
                {
                    if (s1.End1.X == s2.End1.X)
                    {
                        var bottom = Math.Max(s1.End1.Y, s2.End1.Y);
                        var top = Math.Min(s1.End2.Y, s2.End2.Y);
                        if (bottom < top)
                        {
                            intersects.Add(Intersection(s1.End1.X, bottom, s1, s2));
                            intersects.Add(Intersection(s1.End1.X, top, s1, s2));
                        }
                    }
                }
                else
                {
                    if (Utils.InInterval(s1.End1.X, s2.End1.X, s2.End2.X) &&
                        Utils.InInterval(s2.End1.Y, s1.End1.Y, s1.End2.Y))
                    {
                        intersects.Add(Intersection(s1.End1.X, s2.End1.Y, s1, s2));
                    }
                }
            }

            return intersects;
        }

        private static Intersection Intersection(int x, int y, Segment s1, Segment s2)
        {
            var point = new Point(x, y);
            var cost = s1.Cost(point) + s2.Cost(point);
            var intersection = new Intersection(point, cost);
            return intersection;
        }

        private static bool inInterval(Segment s1, Segment s2)
        {
            return s1.End1.X <= s2.End1.X && s1.End2.X >= s2.End1.X;
        }


        private static List<Intersection> Intersects(List<Segment> elements, List<Segment> others)
        {
            var intersects = new List<Intersection>();
            foreach (var element in elements)
            {
                foreach (var other in others)
                {
                    intersects.AddRange(FindIntersects(element, other));
                }
            }

            return intersects;
        }


        public static Intersection Solve(Segment path1, Segment path2)
        {
            var segments = path1.Normalize().ToList();
            var others = path2.Normalize().ToList();
            var intersects = Intersects(segments, others);
            Console.WriteLine("*** Intersects ***");
            Intersection shortest = new Intersection(0, 0, int.MaxValue);
            Intersection cheapest = new Intersection(0, 0, int.MaxValue);
            foreach (var intersection in intersects)
            {
                if (intersection.ManhattanDistance() < shortest.ManhattanDistance())
                {
                    Console.WriteLine(intersection);
                    shortest = intersection;
                }

                if (intersection.Cost < cheapest.Cost)
                {
                    Console.WriteLine(intersection);
                    cheapest = intersection;
                }
            }
            Console.WriteLine("Cheapest: "+cheapest.Cost);
            return shortest;
        }
    }
}