using System;

namespace Extensions
{
    public static class ArrayExtension
    {
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

        public static bool Contains<T>(this T[] source, T arg)
        {
            foreach (var item in source)
            {
                if (item.Equals(arg))
                    return true;
            }

            return false;
        }
    }
}