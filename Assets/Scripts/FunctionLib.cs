using UnityEngine;

using static UnityEngine.Mathf;

public static class FunctionLib
{
    public static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }
    
    public static float WaveHighFrequency(float x, float t)
    {
        return Sin(2f * PI * (x + t)) * 0.5f;
    }
    
    public static float MultiWave(float x, float t) {
        float y = Sin(PI + (t * 0.5f));
        y += Sin(2f * PI * (x + t)) * 0.5f;
        
        return y * (1f / 3f);
    }

    public static float Ripple(float x, float t)
    {
        float d = Abs(x);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }
}
