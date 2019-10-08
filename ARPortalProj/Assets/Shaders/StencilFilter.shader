Shader "Custom/StencilFilter"
{
    Properties
    {
		_Color("Color", Color) = (1,1,1,1)
		//Copy this to other shaders for them to work
		//[Enum(Equal,3,NotEqual,6)] _StencilTest ("Stencil Test", int) = 6
    }
    SubShader
    {
		//Copy this to other shaders for them to work
		Color [_Color]
		Stencil{
			Ref 1
			Comp [_StencilTest]
		}
        
        Pass
        {
           
        }
    }
}
