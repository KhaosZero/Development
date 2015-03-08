// Fake Clouds Shader 2.0 - mgear - http://unitycoder.com/blog
// Converted to Unity from DX11 shader examples/tutorial
// *** Remember to Donate to keep more unity examples coming :) ***

Shader "mShaders/fakeClouds2" {
	Properties {
		_CloudTex ("Cloud (RGB)", 2D) = "white" {}
		_PerlinTex ("Perlin (RGB)", 2D) = "white" {}
		
		_Speed("Speed", Float) = 0.15 // cloud speed
		_Scale("Scale", Float) = 0.5 // cloud scale
		_Brightness("Brightness", Float) = 4 // cloud brightness
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
//		Tags { "RenderType"="Transparent" }
		//LOD 200 //?
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _CloudTex;
		sampler2D _PerlinTex;

		struct Input {
			float2 uv_CloudTex;
			float2 uv_PerlinTex;
		};
		
		half _Speed;
		half _Scale;
		half _Brightness;

		void surf (Input IN, inout SurfaceOutput o) 
		{
		
			float4 perturbValue;
			float4 cloudColor;
			
			// sliding uv
			half translation = _Time.x*_Speed; 
			
			// Sample the texture value from the perturb texture using the translated texture coordinates.
			perturbValue = tex2D (_PerlinTex, half2(IN.uv_PerlinTex.x+translation,IN.uv_PerlinTex.y));
			// Multiply the perturb value by the perturb scale.
			perturbValue = perturbValue * _Scale;
			// Add the texture coordinates as well as the translation value to get the perturbed texture coordinate sampling location.
			perturbValue.xy = perturbValue.xy + IN.uv_CloudTex.xy +translation;
			// Now sample the color from the cloud texture using the perturbed sampling coordinates.
			cloudColor = tex2D (_CloudTex, perturbValue.xy);
			// Reduce the color cloud by the brightness value.
			cloudColor = cloudColor * _Brightness;		

			o.Albedo = cloudColor.rgb;
			o.Alpha = 1;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
