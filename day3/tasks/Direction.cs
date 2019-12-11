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

    public class DirectionFactory
    {
        public static Direction ToDirection(char c)
        {
            return c switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new InvalidOperationException("Invalid direction: " + c)
            };
        }
    }
}