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
                            intersects.Add(new Intersection(leftMost, s2.End1.Y));
                            intersects.Add(new Intersection(rightMost, s2.End1.Y));
                        }
                    }
                }
                else
                {
                    if (Utils.InInterval(s2.End1.X, s1.End1.X, s1.End2.X) &&
                        Utils.InInterval(s1.End1.Y, s2.End1.Y, s2.End2.Y))
                    {
                        intersects.Add(new Intersection(s2.End1.X, s1.End1.Y));
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
                            intersects.Add(new Intersection(s1.End1.X, bottom));
                            intersects.Add(new Intersection(s1.End1.X, top));
                        }
                    }
                }
                else
                {
                    if (Utils.InInterval(s1.End1.X, s2.End1.X, s2.End2.X) &&
                        Utils.InInterval(s2.End1.Y, s1.End1.Y, s1.End2.Y))
                    {
                        intersects.Add(new Intersection(s1.End1.X, s2.End1.Y));
                    }
                }
            }

            return intersects;
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
            Intersection shortest = new Intersection(0, 0);
            foreach (var intersection in intersects)
            {
                if (intersection.ManhattanDistance() < shortest.ManhattanDistance())
                {
                    Console.WriteLine(intersection);
                    shortest = intersection;
                }
            }

            return shortest;
        }
    }
}