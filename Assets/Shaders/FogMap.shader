Shader "Unlit/FogMap"
{
    Properties
    {
    }
    SubShader
    {
        Tags { "RenderType"="Room" }
        LOD 100

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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            int _MoodIndex;
            int _RoomIndex;

            fixed4 frag (v2f i) : SV_Target
            {
                return float(_RoomIndex) / 255;
                return fixed4(0,1,0,1);
            }
            ENDCG
        }
    }
}
