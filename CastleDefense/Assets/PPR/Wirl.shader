Shader "Hidden/Wirl"
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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			uniform sampler2D _CameraDepthTexture;
			uniform float _shift;
			uniform float _red;
			uniform float _fade;
            fixed4 frag (v2f i) : SV_Target
            {
				float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
				depth = 1- Linear01Depth(depth);

				fixed4 colShift = tex2D(_MainTex, i.uv+float2(_shift*depth,0.0f));
				fixed4 colRegular = tex2D(_MainTex, i.uv-float2(_shift*depth, 0.0f));
				fixed4 col;
				col.r = colShift.r;
				col.g = colRegular.g;
				col.b = colRegular.b;
                return col;
            }
            ENDCG
        }
    }
}
