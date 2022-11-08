using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensions
{

    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    public static T GetRandomItem<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}

public static class Util
{
    public static float SolveQuadratic(float a, float b, float c)

    {

        float sqrtpart = b * b - 4 * a * c;

        float x, x1, x2;

        if (sqrtpart > 0)

        {

            x1 = (-b + Mathf.Sqrt(sqrtpart)) / (2 * a);

            x2 = (-b - Mathf.Sqrt(sqrtpart)) / (2 * a);

            return Mathf.Max(x1, x2);
        }
        else if (sqrtpart < 0)
        {
            return 0;
            //sqrtpart = -sqrtpart;
            //x = -b / (2 * a);
            //img = Mathf.Sqrt(sqrtpart) / (2 * a);
            //Console.WriteLine("Two Imaginary Solutions: {0,8:f4} + {1,8:f4} i or {2,8:f4} + {3,8:f4} i", x, img, x, img);
        }
        else

        {
            x = (-b + Mathf.Sqrt(sqrtpart)) / (2 * a);
            return x;
        }

    }
}