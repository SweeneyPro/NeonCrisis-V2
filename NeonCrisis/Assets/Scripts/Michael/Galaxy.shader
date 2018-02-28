Shader "Unlit/Galaxy"
{
	Properties
	{
		//_MainTex ("Texture", 2D) = "white" {}


		iResolution ("Resolution", Vector) = (0, 0, 0, 0)
		iTime ("Time", Float) = 0 
		iTimeDelta ("TimeDelta", Float) = 0 
		iFrame("Frame", Int) = 0
		iChannelTime("ChannelTime", Float) = 0
		iChannelResolution("ChannelResolution", Vector) = (0,0,0,0)
		iMouse("Mouse", Vector) = (0,0,0,0)
		iChannel("Channel", 2D) = "" {}
		iDate("Date", Vector) = (0,0,0,0)
		iSampleRate("SampleRate", Float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"




			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				//UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 Resolution = (1,2,3,4);
			float timetest =1;

			float field(in float3 p) {
				float strength = 7. + .03 * log(1.e-6 + frac(sin(timetest) * 4373.11));
				float accum = 0.;
				float prev = 0.;
				float tw = 0.;
				for (int i = 0; i < 32; ++i) {
					float mag = dot(p, p);
					p = abs(p) / mag + float3(-.5, -.4, -1.5);
					float w = exp(-float(i) / 7.);
					accum += w * exp(-strength * pow(abs(mag - prev), 2.3));
					tw += w;
					prev = mag;
				}
				return max(0., 5. * accum / tw - .7);
			}
			/*
			void mainImage( out float4 fragColor, in float2 fragCoord ) {
				float2 uv = 2. * fragCoord.xy / Resolution.xy - 1.;
				float2 uvs = uv * Resolution.xy / max(Resolution.x, Resolution.y);
				float3 p = float3(uvs.x / 4., 0,0) + float3(1., -1.3, 0.);
				p += .2 * float3(sin(timetestiTime / 16.), sin(timetestiTime / 12.),  sin(timetestiTime / 128.));
				float t = field(p);
				float v = (1. - exp((abs(uv.x) - 1.) * 6.)) * (1. - exp((abs(uv.y) - 1.) * 6.));
				fragColor = lerp(.4, 1., v) * float4(1.8 * t * t * t, 1.4 * t * t, t, 1.0);
			}
			*/
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);

				
				float3 p = float3(i.uv.x / 4., i.uv.y/4,0) + float3(1., -1.3, 0.);
				p += .2 * float3(sin(timetest/*iTime*/ / 16.), sin(timetest/*iTime*/ / 12.),  sin(timetest/*iTime*/ / 128.));
				float t = field(p);
				float v = (1. - exp((abs(i.uv.x) - 1.) * 6.)) * (1. - exp((abs(i.uv.y) - 1.) * 6.));
				float4 fragColor = lerp(.4, 1., v) * float4(1.8 * t * t * t, 1.4 * t * t, t, 1.0);
				return fragColor;
			}

			ENDCG
		}
	}
}


/*float2 uv = 2. *  / Resolution.xy - 1.;
				float2 uvs = uv * Resolution.xy / max(Resolution.x, Resolution.y);
				float3 p = float3(uvs.x / 4., 0,0) + float3(1., -1.3, 0.);
				p += .2 * float3(sin(timetestiTime / 16.), sin(timetestiTime / 12.),  sin(timetestiTime / 128.));
				float t = field(p);
				float v = (1. - exp((abs(uv.x) - 1.) * 6.)) * (1. - exp((abs(uv.y) - 1.) * 6.));
				float4 fragColor = lerp(.4, 1., v) * float4(1.8 * t * t * t, 1.4 * t * t, t, 1.0);
				return fragColor;
*/