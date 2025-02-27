// Upgrade NOTE: commented out 'float4x4 _CameraToWorld', a built-in variable
// Upgrade NOTE: replaced '_CameraToWorld' with 'unity_CameraToWorld'

Shader "Hidden/VolumetricFog"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 rayDir : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                
                o.rayDir = mul(unity_CameraInvProjection, float4(v.uv * 2 - 1, 1, 1)).xyz;
                
                return o;
            }
            
            sampler2D _CameraDepthTexture;
            sampler2D _MainTex;
            sampler2D _FogMap;

            float4x4 _InverseView;
            
            float4 _FogColors[32];

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float z = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
                
                float3 viewPos = i.rayDir * LinearEyeDepth(z);

                float3 worldPos = mul(_InverseView, float4(viewPos, 1)).xyz;

                return frac(worldPos.x);
                return float4(frac(abs(worldPos)), 1);
                

                col.rgb = i.rayDir;
                
                return col;
            }
            ENDCG
        }
    }
}
