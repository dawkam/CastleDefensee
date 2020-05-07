Shader "Hidden/3d"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _intensity("Intenstity of effect", Range(0,1)) = 1
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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            uniform float _intensity;

            fixed4 frag (v2f i) : SV_Target
            {

                float2 c = i.uv; //c.x, c.y
                
                fixed4 colR = tex2D(_MainTex, c + float2(_intensity, 0 ));
                colR.g = 0;
                colR.b = 0;

                float4 colG = tex2D(_MainTex, c);
                //colG.b = 0;
                colG.r = 0;

                float4 colB = tex2D(_MainTex, c - float2(_intensity, 0));
                colB.r = 0;
                colB.g = 0;

                return  colG +  colR ;
            }
            ENDCG
        }
    }
}
