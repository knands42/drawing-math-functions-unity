using UnityEngine;

using static UnityEngine.Mathf;

public static class FunctionLib
{
    public delegate float Function(float x, float z, float t);

    public enum FunctionName { Wave, Multiwave, Ripple }
    private static readonly Function[] Functions = { Wave, MultiWave, Ripple };

    public static Function GetFunction(FunctionName name)
    {
        return Functions[(int)name];
    }
    
    public static float Wave(float x, float z, float t)
    {
        return Sin(PI * (x + z + t));
    }
    
    public static float WaveHighFrequency(float x, float z, float t)
    {
        return Sin(2f * PI * (x + t)) * 0.5f;
    }
    
    public static float MultiWave(float x, float z,float t) {
        float y = Sin(PI * (t * 0.5f + x));
        y += 0.5f * Sin(2f * PI * (z + t));
        y += Sin(PI * (x + z + 0.25f * t));
        
        return y * (1f / 3f);
    }

    public static float Ripple(float x, float z, float t)
    {
        float d = Abs(x * x + z * z);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }
}
