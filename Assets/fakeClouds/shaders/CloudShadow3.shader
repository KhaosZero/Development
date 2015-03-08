// fake shadow for clouds, using animated projector - mgear - http://unitycoder.com/blog
// version 3.0, not finished..

Shader "mShaders/CloudShadows3"
{ 
Properties
{
    _Color ("Main Colour", Color) = (1,1,1,0)  
    _ShadowTex ("Cookie", 2D) = "gray" { TexGen ObjectLinear }
	
//	_CloudTex ("Cloud (RGB)", 2D) = "white" {}
	_PerlinTex ("Perlin (RGB)", 2D) = "white" {}
		
	_Speed("Speed", Float) = 0.15 // cloud speed
	_Scale("Scale", Float) = 0.5 // cloud scale
	_Brightness("Brightness", Float) = 4 // cloud brightness	
	
}

Subshader
{
    Tags { "RenderType"="Transparent"  "Queue"="Transparent+100"}
    Pass
    {
        ZWrite Off
        Offset -1, -1
		
		Cull Off
		
        Fog { Mode Off }

        //AlphaTest Greater .1
        AlphaTest Less 1
        ColorMask RGB
        Blend One SrcAlpha
				
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma fragmentoption ARB_fog_exp2
		#pragma fragmentoption ARB_precision_hint_fastest
		#include "UnityCG.cginc"

		struct v2f
		{
			float4 pos : SV_POSITION;
			float2  uv_Main     : TEXCOORD0;
			float2 uv_PerlinTex: TEXCOORD0;	
		};

		sampler2D _ShadowTex;
		sampler2D _PerlinTex;
		
		float4 _Color;
		float4x4 _Projector;

		half _Speed;
		half _Scale;
		half _Brightness;


		v2f vert(appdata_tan v)
		{
			v2f o;
			o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			//o.uv_Main = mul (_Projector, v.texcoord).xy;
			o.uv_Main = mul (_Projector, v.vertex).xy;
			return o;
		}

		half4 frag (v2f i) : COLOR
		{
	
			float4 perturbValue;
			float4 cloudColor;

			// sliding uv
			half translation = _Time.x*_Speed; 
			
			
			// Sample the texture value from the perturb texture using the translated texture coordinates.
//			perturbValue = tex2D (_PerlinTex, half2(IN.uv_PerlinTex.x+translation,IN.uv_PerlinTex.y));
			perturbValue = tex2D (_PerlinTex, half2(i.uv_PerlinTex.x,i.uv_PerlinTex.y+translation));
			
			// Multiply the perturb value by the perturb scale.
			perturbValue = perturbValue * _Scale;
			// Add the texture coordinates as well as the translation value to get the perturbed texture coordinate sampling location.
//			perturbValue.xy = perturbValue.xy + float2(i.uv_Main.x + translation,i.uv_Main.y - translation);
			perturbValue.xy = float2(perturbValue.x,-perturbValue.y) + float2(i.uv_Main.x + translation,i.uv_Main.y - translation);
			// Now sample the color from the cloud texture using the perturbed sampling coordinates.
//			cloudColor = tex2D (_CloudTex, perturbValue.xy);
//			cloudColor = tex2D(_ShadowTex, perturbValue.xy) * _Color;
			cloudColor = tex2D(_ShadowTex, float2(perturbValue.x,-perturbValue.y)) * _Color;
			
			// Reduce the color cloud by the brightness value.
			cloudColor = cloudColor * _Brightness;					

			//alf4 tex = tex2Dproj (_ShadowTex, UNITY_PROJ_COORD(i.uv_Main));
//			half4 tex = tex2D(_ShadowTex, i.uv_Main) * _Color;
			cloudColor.a = 1-cloudColor.a;
			return cloudColor;
		}
		ENDCG

			}
		}
}