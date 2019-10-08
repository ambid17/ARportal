Shader "Custom/PortalWindow"
{
    SubShader
    {
		Stencil{
			Ref 1
			Pass replace
		}

		ZWrite off
		ColorMask 0
		Cull off
        Pass
		{

		}
    }

	
    FallBack "Diffuse"
}
