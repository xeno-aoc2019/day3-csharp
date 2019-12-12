using System;
using System.Diagnostics;

namespace tasks
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class DirectionFactory
    {
        public static Direction ToDirection(char c)
        {
            var direction = c switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new InvalidOperationException("Invalid direction: " + c)
            };
            // Console.WriteLine("char="+c+" dir="+direction);
            return direction;
        }
    }
}