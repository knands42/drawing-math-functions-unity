Shader "Basics/BasicTexturing"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
    }
    
    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
        }
        
        Pass
        {
            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            #pragma vertex vert
            #pragma fragment frag

            float4 _BaseColor;
            
            struct appdata
            {
                float4 postitionOS : POSITION;
            };
            
            struct v2f
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
            };
            
            v2f vert(appdata v)
            {
                v2f output = (v2f)0;
                output.positionCS = TransformObjectToHClip(v.postitionOS.xyz);
                output.positionWS = TransformObjectToWorld(v.postitionOS.xyz);
                return output;
            }
            
            float4 frag(v2f i) : SV_TARGET
            {
                float gradient = (i.positionWS.x + 1) * 0.5;
                return float4(gradient, gradient * 0.5, 1 - gradient, 1 + gradient);
            }
            
            ENDHLSL
        }
    }
}