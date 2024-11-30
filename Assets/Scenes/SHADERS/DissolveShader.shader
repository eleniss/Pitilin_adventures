Shader "Custom/DissolveShader"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _DissolveTex("Dissolve Texture", 2D) = "white" {}
        _DissolveAmount("Dissolve Amount", Range(0, 1)) = 0
    }
        SubShader
        {
            Tags { "Queue" = "Transparent" }
            LOD 200

            Pass
            {
                Tags { "LightMode" = "ForwardBase" }

                // Enable blending for transparency
                Blend SrcAlpha OneMinusSrcAlpha
                ZWrite Off // Do not write to the depth buffer

                CGPROGRAM
                #pragma surface surf Standard

                sampler2D _MainTex;
                sampler2D _DissolveTex;
                float _DissolveAmount;

                struct Input
                {
                    float2 uv_MainTex;
                };

                void surf(Input IN, inout SurfaceOutputStandard o)
                {
                    float dissolve = tex2D(_DissolveTex, IN.uv_MainTex).r;
                    if (dissolve > _DissolveAmount)
                    {
                        discard; // Make parts of the object invisible
                    }

                    fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                    o.Albedo = c.rgb;
                    o.Alpha = c.a;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
