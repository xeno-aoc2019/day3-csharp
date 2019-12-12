using System.Runtime.Intrinsics.X86;

namespace tasks
{
    public static class Utils
    {
        public static bool InInterval(int x, int start, int end)
        {
            return x >= start && x <= end;
        }
    }
}