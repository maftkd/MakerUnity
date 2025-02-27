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

            int _NumSteps;

            float4 _FogBounds;
            
            int getRoomCode(float3 worldPos)
            {
                float2 uv = (worldPos.xz - _FogBounds.xy) / _FogBounds.z;
                if(uv.x < 0 || uv.x > 1 || uv.y < 0 || uv.y > 1)
                {
                    return -1;
                }
                else if(worldPos.y < -1 || worldPos.y > 2)
                {
                    return -1;
                }
                else
                {
                    float roomCodeFrac = tex2Dlod(_FogMap, float4(uv, 0, 0)).r;
                    if(roomCodeFrac >= 1)
                    {
                        return -1;
                    }
                    return int(round(roomCodeFrac * 255));
                }
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float z = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
                
                float3 viewPos = i.rayDir * LinearEyeDepth(z);

                float3 worldPos = mul(_InverseView, float4(viewPos, 1)).xyz;
                int roomCode = getRoomCode(worldPos);
                //return roomCode >= 0;
                //return float(roomCode) / 255;
                
                float2 uv = (worldPos.xz - _FogBounds.xy) / _FogBounds.z;
                //return float4(uv, 0, 1);
                
                float3 rayStart = _WorldSpaceCameraPos;
                float3 rayEnd = worldPos;
                float3 rayDir = normalize(rayEnd - rayStart);

                float fog = 0;
                float rayLength = length(rayEnd - rayStart);
                if(rayLength > 500)
                {
                    return col;
                }
                float stepSize = rayLength / _NumSteps;
                for(int i = 1; i <= _NumSteps; i++)
                {
                    float t = i / float(_NumSteps);
                    float3 samplePos = lerp(rayStart, rayEnd, t);//rayStart + rayDir * t;
                    int rc = getRoomCode(samplePos);

                    float fogdelta = rc >= 0 ? 1 : 0;
                    //temp assume there's fog everywhere
                    fog += 0.05 * fogdelta * stepSize;
                }
                fog = saturate(fog);
                return lerp(col, 0.5, fog);
            }
            ENDCG
        }
    }
}
