Shader "ImageEffectShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_MainTex2("Texture", 2D) = "white" {}
		_TFloat("My Float", float) = 0.5
		_Center("Center", Vector) = (0,0,0,0)
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

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				sampler2D _MainTex2;
				float _TFloat;
				float4 _Center;

				fixed4 frag(v2f i) : SV_Target
				{
					
					/*
					float4 t = float4(1,2,3,4);
					t = float4(1, float2(1, 2), 3);
					float x = t.r + r.g + r.z;
					t = 0;
					t += 0.5;
					*/

					/*
					float2 uv = i.uv;
					//uv.x = 1 - uv.x;
					float t = 0.001;// _TFloat / 100;
					float4 color0 = tex2D(_MainTex, uv + float2(0.0, 0));
					float4 color1 = tex2D(_MainTex, uv+ float2(t, 0));
					float4 color2 = tex2D(_MainTex, uv + float2(-t, 0));
					float4 color3 = tex2D(_MainTex, uv + float2(0, t));
					float4 color4 = tex2D(_MainTex, uv + float2(0, -t));
					float4 color;
					color = (color1 - color2)+0.5;
					color.a = 1;
					uv.y += 0.01 * sin(uv.x * 63);
					color = tex2D(_MainTex, uv+ _TFloat/100);
					return color;
					*/

					/*
					fixed4 color = tex2D(_MainTex, i.uv);
					float temp = (color.r + color.g + color.b) / 3;
					color.rgb = temp;
					return color;
					*/

					/*
					color.rgb = 0.3*color.r + 0.59*color.g + 0.11*color.b;
					color.r *= 1.1;
					color.g *= 1.05;
					color.b *= 0.9;
					return color;
					*/

					/*
					float t = 1 * _TFloat;
					float2 uv = i.uv;
					uv.x = uv.x + 0.1 * sin(2*3.14*uv.y+t);
					uv.y = uv.y + 0.1 * sin(3*2 * 3.14*uv.x + t);
					float4 color = tex2D(_MainTex, uv);
					return color;
					*/

					//float t = 1*_TFloat;
					//fixed4 color = tex2D(_MainTex, i.uv + fixed2(0.1*sin(i.uv.x*6.28+t), 0.1*sin(i.uv.y*6.28+t)));

					/*
					fixed4 color1 = tex2D(_MainTex, i.uv + fixed2(0.01, 0));
					fixed4 color2 = tex2D(_MainTex, i.uv + fixed2(0.02, 0));
					fixed4 color3 = tex2D(_MainTex, i.uv + fixed2(0.03, 0));
					fixed4 color4 = tex2D(_MainTex, i.uv + fixed2(0.04, 0));
					fixed4 color5 = tex2D(_MainTex, i.uv + fixed2(0.05, 0));
					fixed4 color6 = tex2D(_MainTex, i.uv + fixed2(0.06, 0));
					fixed4 color7 = tex2D(_MainTex, i.uv + fixed2(0.07, 0));
					color = 0.5 * color + 0.2 * color1 + 0.1 * color2 +	0.2*(color3 + color4 + color5 + color6 + color7) / 5;
					//return color;
					*/

					//Greyscale effect: 
					/*
					fixed4 color = tex2D(_MainTex, i.uv);
					float temp = (color.r + color.g + color.b) / 3;

					color.rgb = temp;
					return color;
					*/
					//Cách sử dụng biến t từ script, khai báo như sau:
					//float t = 1*_TFloat;

					// Yellow old effect: 
					/*
					fixed4 color = tex2D(_MainTex, i.uv);
					float temp = (color.r + color.g + color.b) / 3;
					color.rgb = float3(temp*1.1, temp*0.9, temp*0.5);
					return color;
					*/

					//Effect 3:
					/*
					float tt = _TFloat;
					//tt = 0.01;
					if (tt > 0.1)
						tt = 0.1;
					float4 color1 = tex2D(_MainTex, i.uv + float2(-tt, 0));
					float4 color2 = tex2D(_MainTex, i.uv + float2(tt, 0));
					float4 color3 = tex2D(_MainTex, i.uv + float2(0, -tt));
					float4 color4 = tex2D(_MainTex, i.uv + float2(0, tt));
					float4 color0 = tex2D(_MainTex, i.uv);
					float4 color = (color0 + color1 + color2 + color3 + color4) / 5;
					return color;
					*/

					//Effect 4: Emboss
					/*
					float tt = 0.001;
					if (tt > 0.1)
						tt = 0.1;
					float4 color1 = tex2D(_MainTex, i.uv + float2(-tt, 0));
					float4 color2 = tex2D(_MainTex, i.uv + float2(tt, 0));
					float4 color = (color2 - color1) / 2 + 0.5; // [-1, 1] ==> [0,1]
					color.a = 1;
					return color;
					*/

					//Effect 5:
					/*
					float2 TextureCoordinate = i.uv;
					float tt = 0.1;
					float t = _TFloat;
					float tx = tt * sin(12.56 * TextureCoordinate.x + t);
					float ty = tt * cos(3.14 * TextureCoordinate.y + t);
					float4 color = tex2D(_MainTex, i.uv + float2(tx, ty));
					color.a = 1;
					return color;
					*/

					//Effect 6:
					/*
					float4 color = tex2D(_MainTex, i.uv);
					float t = _TFloat;
					color.rgb *= (t - i.uv.x - i.uv.y);
					return color;
					*/

					//Effect 7:
					/*
					float t = _TFloat;
					float4 color;
					float2 uv = i.uv;
					color = tex2D(_MainTex, uv);
					float4 color2;
					color2 = tex2D(_MainTex2, uv);

					float tt = t - uv.x + uv.y;
					if (tt > 1)
						tt = 1;
					if (tt < 0)
						tt = 0;
					return color * tt + color2 * (1 - tt);
					*/

					//Effect 8:
					/*
					float4 color;
					float t = _TFloat;
					float2 uv = i.uv;
					color = tex2D(_MainTex, uv / t);
					float4 color2;
					color2 = tex2D(_MainTex2, uv);
					return color + color2;
					*/

					//Effect 9:
					/*
					float4 color;
					float2 uv = i.uv;
					float t = _TFloat;

					float2 uvNew;
					uvNew.x = (uv.x - _Center.x) / t + _Center.x;
					uvNew.y = (uv.y - _Center.y) / t + _Center.y;

					color = tex2D(_MainTex, uvNew);
					return color;
					*/


					//Effect 10:
					
					float4 color;
					float2 uv = i.uv;
					float2 uvNew;
					float t = _TFloat;
					uvNew.x = uv.x;
					uvNew.y = uv.y + 0.01 * sin(uv.x * 63 + uv.y * 63 + t);
					color = tex2D(_MainTex, uvNew);
					return color;
					
				}
				ENDCG
			}
		}
}
