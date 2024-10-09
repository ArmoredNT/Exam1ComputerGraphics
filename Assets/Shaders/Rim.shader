Shader "Custom/Rim"
{
    Properties
    {
        _RimColor ("Rim Color", Color) = (0, 0.5, 0.5, 0.0)
        _RimPower ("Rim Power", Range(0.5, 8.0)) = 3.0
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input {
            float3 viewDir;
    };

        float4 _RimColor;
        float4 _BaseColor;
        float _RimPower;
        

        void surf (Input IN, inout SurfaceOutput o) {
            //half rim = dot(normalize(IN.viewDir), o.Normal);
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal)); //Does the dot product between the view direction and the normals. Saturates the value and inverses it by substracting it from one
            //o.Emission = _RimColor.rgb * rim;
            o.Emission = _RimColor.rgb * pow(rim, _RimPower); //sets the emission to the rim value multiplied by the rim colour
            o.Albedo = _BaseColor.rgb; //adds the base colour
            }
        ENDCG
    }
    Fallback "Diffuse"
}