using System;
using System.Collections.Generic;
using UnityEngine;

public class CMath
{
    /// <summary>
    /// Floor: returns the passed value floored (rounded lower) expected 1.75 --> 1.0
    /// Uses the fast floor method adopted from java to and in c# to be used over Nath.Floor from system.
    /// </summary>
    #region Floor
    public static int Floor(float p)
    {
        int xi = (int)p;
        return p < xi ? xi - 1 : xi;
    }

    public static int Floor(double p)
    {
        int xi = (int)p;
        return p < xi ? xi - 1 : xi;
    }

    public static Vector2 Floor(Vector2 p)
    {
        return new Vector2(Floor(p.x), Floor(p.y));
    }

    public static Vector3 Floor(Vector3 p)
    {
        return new Vector3(Floor(p.x), Floor(p.y), Floor(p.y));
    }

    public static Vector4 Floor(Vector4 p)
    {
        return new Vector4(Floor(p.x), Floor(p.y), Floor(p.z), Floor(p.w));
    }
    #endregion

    /// <summary>
    /// Fract: returns the fractional part of a value so 1.75 --> 0.75
    /// </summary>
    #region Fract
    public static float Fract(float p)
    {
        return p - Floor(p);
    }

    public static double Fract(double p)
    {
        return p - Floor(p);
    }

    public static Vector2 Fract(Vector2 p)
    {
        return p - Floor(p);
    }

    public static Vector3 Fract(Vector3 p)
    {
        return p - Floor(p);
    }

    public static Vector4 Fract(Vector4 p)
    {
        return p - Floor(p);
    }
    #endregion

    /// <summary>
    /// Mix: returns a value base upon to input parameters controlled by an intensity where the higher a is the more the value leans to y.
    /// </summary>
    #region Mix
    public static float Mix(float x, float y, float a)
    {
        return x * (1 - a) + y * a;
    }

    public static double Mix(double x, double y, double a)
    {
        return x * (1 - a) + y * a;
    }

    public static Vector2 Mix(Vector2 x, Vector2 y, float a)
    {
        return new Vector2(x.x * (1 - a) + y.x * a, x.y * (1 - a) + y.y * a);
    }

    public static Vector3 Mix(Vector3 x, Vector3 y, float a)
    {
        return new Vector3(x.x * (1 - a) + y.z * a, x.y * (1 - a) + y.y * a, x.z * (1 - a) + y.z * a);
    }
    #endregion

    /// <summary>
    /// Dot: returns the dot product of a passed vector.
    /// </summary>
    #region Dot
    public static float Dot(int[] g, float x, float y)
    {
        return g[0] * x + g[1] * y;
    }

    public static float Dot(int[] g, float x, float y, float z)
    {
        return g[0] * x + g[1] * y + g[2] * z;
    }

    public static float Dot(int[] g, float x, float y, float z, float w)
    {
        return g[0] * x + g[1] * y + g[2] * z + g[3] * w;
    }

    public static float Dot(Vector2 x, Vector2 y)
    {
        return x.x * y.x + x.y * y.y;
    }

    public static float Dot(Vector3 x, Vector3 y)
    {
        return x.x * y.x + x.y * y.y + x.z * y.z;
    }
    #endregion

    /// <summary>
    /// Abs: returns the absolut value of the passed value 1 --> 1 or -2.25 --> 2.25
    /// </summary>
    #region Abs
    public static int Abs(int p)
    {
        return p < 0 ? -p : p;
    }

    public static float Abs(float p)
    {
        return p < 0 ? -p : p;
    }

    public static double Abs(double p)
    {
        return p < 0 ? -p : p;
    }

    public static Vector2 Abs(Vector2 p)
    {
        return new Vector2(Abs(p.x), Abs(p.y));
    }

    public static Vector3 Abs(Vector3 p)
    {
        return new Vector3(Abs(p.x), Abs(p.y), Abs(p.z));
    }
    #endregion

    /// <summary>
    /// Fade:
    /// </summary>
    #region Fade
    public static float Fade(float p)
    {
        return p * p * p * (p * (p * 6 - 15) + 10);
    }
    #endregion

    /// <summary>
    /// Lerp: returns the linear interpolation between two values.
    /// </summary>
    #region Lerp
    public static float Lerp(float t, float a, float b)
    {
        return a + t * (b - a);
    }
    #endregion

    /// <summary>
    /// Grad: 
    /// </summary>
    #region Grad
    public static float Grad(int hash, float x, float y, float z)
    {
        int h = hash & 15;                      // CONVERT LO 4 BITS OF HASH CODE
        float u = h < 8 ? x : y,                 // INTO 12 GRADIENT DIRECTIONS.
               v = h < 4 ? y : h == 12 || h == 14 ? x : z;
        return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
    }
    #endregion

    /// <summary>
    /// SCurve: 
    /// </summary>
    #region SCurve
    public static float SCurve(float t)
    {
        return t * t * (3.0f - (2.0f * t));
    }

    public static double SCurve(double t)
    {
        return t * t * (3.0 - (2.0 * t));
    }
    #endregion

    /// <summary>
    /// Swap: swaps x and y around via reference.
    /// </summary>
    #region Swap
    public static void Swap(ref int x, ref int y)
    {
        int k = x; x = y; y = k;
    }

    public static void Swap(ref float x, ref float y)
    {
        float k = x; x = y; y = k;
    }

    public static void Swap(ref double x, ref double y)
    {
        double k = x; x = y; y = k;
    }
    #endregion

    /// <summary>
    /// QuinticEase: returns the input p to 30p^4 - 60p^3 + 30p^2
    /// </summary>
    #region QuinticEase
    public static float QuinticEase(float p) // taken from http://www.iquilezles.org/www/articles/morenoise/morenoise.htm all credit goes here, only this equation was used here.
    {
        return (30 * p * p * p * p) - (60 * p * p * p) + (30 * p * p);
    }

    public static double QuinticEase(double p) // taken from http://www.iquilezles.org/www/articles/morenoise/morenoise.htm all credit goes here, only this equation was used here.
    {
        return (30 * p * p * p * p) -
                (60 * p * p * p) +
                (30 * p * p);
    }
    #endregion

    /// <summary>
    /// CorFallOff:
    /// </summary>
    #region CorFallOff
    public static float CorFallOff(float p)
    {
        return (5 * p * p * p * p) -
                (15 * p * p * p) +
                (10 * p * p);
    }

    public static double CorFallOff(double p)
    {
        return (5 * p * p * p * p) -
                (15 * p * p * p) +
                (10 * p * p);
    }
    #endregion

    /// <summary>
    /// CorDistribute:
    /// </summary>
    #region CorDistribute
    public static float CorDistribute(float p)
    {
        return (9 * p * p * p * p * p * p) -
                (4 * p * p * p * p * p) +
                (2 * p * p * p * p) -
                (16 * p * p * p) +
                (10 * p * p);
    }

    public static double CorDistribute(double p)
    {
        return (9 * p * p * p * p * p * p) -
                (4 * p * p * p * p * p) +
                (2 * p * p * p * p) -
                (16 * p * p * p) +
                (10 * p * p);
    }
    #endregion

    /// <summary>
    /// CorEaseLow:
    /// </summary>
    #region CorEaseLow
    public static float CorEaseLow(float p)
    {
        return (p * p * p) -
                (2 * p * p) +
                (2 * p);
    }

    public static double CorEaseLow(double p)
    {
        return (p * p * p) -
                (2 * p * p) +
                (2 * p);
    }
    #endregion

    /// <summary>
    /// CorEaseMid:
    /// </summary>
    #region CorEaseMid
    public static double CorEaseMid(float p)
    {
        return (2 * p * p * p) -
                (2 * p * p) +
                p;
    }

    public static double CorEaseMid(double p)
    {
        return (2 * p * p * p) -
                (2 * p * p) +
                p;
    }
    #endregion

    /// <summary>
    /// CorEaseHigh:
    /// </summary>
    #region CorEaseHigh
    public static float CorEaseHigh(float p)
    {
        return (p * p * p) -
                (2 * p * p) +
                p;
    }

    public static double CorEaseHigh(double p)
    {
        return (p * p * p) -
                (2 * p * p) +
                p;
    }
    #endregion
}

