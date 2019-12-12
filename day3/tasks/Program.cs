using System;
using System.IO;
using System.Linq;

namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = ProvidedPaths.read();
            Console.WriteLine(paths.Path1.PathString());
            Console.WriteLine(paths.Path2.PathString());
            var solution = Solver.Solve(paths.Path1, paths.Path2);
        }
    }
}