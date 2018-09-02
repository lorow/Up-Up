Shader "UpAndUp/Gradient-background" {
	Properties {
		_Color ("EndColor", Color) = (1,1,1,1)
		_Color1 ("StartColor", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		fixed4 _Color1;

		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * lerp(_Color1, _Color, screenUV.y);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "VertexLit"
}
