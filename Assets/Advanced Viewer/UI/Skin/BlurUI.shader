Shader "PiXYZ/Blurred UI" {

		Properties
		{
			_MainTex("_MainTex", 2D) = "white" {}      // Note _MainTex is a special name: This can also be accessed from C# via mainTexture property. 
			_Size("Size", float) = 1
		}
			SubShader
			{
				GrabPass {Tags{"LightMode" = "Always"}}

				Pass
				{
				Name "ColorizeSubshader"

				// ---
				// For Alpha transparency:   https://docs.unity3d.com/462/Documentation/Manual/SL-SubshaderTags.html
				Tags
				{
					"Queue" = "Transparent"
					"RenderType" = "Transparent"
				}
				Blend SrcAlpha OneMinusSrcAlpha
				// ---

				CGPROGRAM
				#pragma vertex   vert 
				#pragma fragment  frag
				#pragma fragmentoption ARB_precision_hint_fastest 
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				sampler2D _GrabTexture;
				float4 _GrabTexture_TexelSize;
				float _Size;

				//fixed4 _Color0;

				// http://wiki.unity3d.com/index.php/Shader_Code : 
				// There are some pre-defined structs e.g.: v2f_img, appdata_base, appdata_tan, appdata_full, v2f_vertex_lit
				//
				// but if you want to create a custom struct, then the see Acceptable Field types and names at http://wiki.unity3d.com/index.php/Shader_Code 
				// my custom struct recieving data from unity
				struct appdata
				{
					float4 vertex   : POSITION;  // The vertex position in model space.          //  Name&type must be the same!
					float4 texcoord : TEXCOORD0; // The first UV coordinate.                     //  Name&type must be the same!
					float4 color    : COLOR;     //    The color value of this vertex specifically. //  Name&type must be the same!
				};

				// my custom Vertex to Fragment struct
				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 uvgrab : COLOR;
					float4 vertex : SV_POSITION;
				};

				v2f vert(appdata  v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);  // Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
					o.uv = v.texcoord.xy;

#if UNITY_UV_STARTS_AT_TOP
					float scale = -1.0;
#else
					float scale = 1.0;
#endif
					o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
					o.uvgrab.zw = o.vertex.zw;
					return o;
				}

				float4 frag(v2f  i) : COLOR
				{
					half4 sum = half4(0,0,0,0);

					#define GRABPIXEL(weight,kernelx) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx*_Size, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w))) * weight

					sum += GRABPIXEL(0.05, -4.0);
					sum += GRABPIXEL(0.09, -3.0);
					sum += GRABPIXEL(0.12, -2.0);
					sum += GRABPIXEL(0.15, -1.0);
					sum += GRABPIXEL(0.18, 0.0);
					sum += GRABPIXEL(0.15, +1.0);
					sum += GRABPIXEL(0.12, +2.0);
					sum += GRABPIXEL(0.09, +3.0);
					sum += GRABPIXEL(0.05, +4.0);

					return sum * tex2D(_MainTex, i.uv);
				}

				ENDCG
			}
			}
				//Fallback "Diffuse"
	}