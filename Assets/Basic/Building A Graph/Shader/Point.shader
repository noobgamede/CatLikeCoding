Shader "Building A Graph/Point"{
    SubShader{
        CGPROGRAM
        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0
        struct Input{
            float3 worldPos;
        };
        void ConfigureSurface(Input input,inout SurfaceOutputStandard surface){
            surface.Smoothness = .5;
            surface.Albedo.rg = input.worldPos.xy*.5+.5;
        }
        ENDCG
    }
    FallBack "Diffuse"
}