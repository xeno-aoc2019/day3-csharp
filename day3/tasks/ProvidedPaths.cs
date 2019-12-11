using System;
using System.IO;
using System.Linq;

namespace tasks
{
    public class ProvidedPaths
    {
        public static Paths read()
        {
            var pwd = Directory.GetCurrentDirectory();
            Console.WriteLine(pwd);
            var lines = File.ReadLines("input.txt").ToList();
            var path1 = lines[0].Split(",")
                .Aggregate(Segment.origo(), (segment, s) => new Segment(s, segment));
            var path2 = lines[1].Split(",")
                .Aggregate(Segment.origo(), (segment, s) => new Segment(s, segment));
            return new Paths(path1, path2);
        }

        public static Paths testPaths()
        {
            var path1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(",")
                .Aggregate(Segment.origo(), (segment, s) => new Segment(s, segment));
            var path2 = "U62,R66,U55,R34,D71,R55,D58,R83".Split(",")
                .Aggregate(Segment.origo(), (segment, s) => new Segment(s, segment));
            return new Paths(path1, path2);
        }
    }
}