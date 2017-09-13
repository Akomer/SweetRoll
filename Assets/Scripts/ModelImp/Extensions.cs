
using System.Collections.Generic;
using System;

public static class Extensions
{
    public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        if(enumerable == null)
            return;
        foreach(var e in enumerable)
            action(e);
    }
}
