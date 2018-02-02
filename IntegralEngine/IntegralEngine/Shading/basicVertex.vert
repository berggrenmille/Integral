#version 430 core 

//Uniform variables
uniform vec3 inPosition;

//Attribute list variables
layout(location = 0) in vec3 vPosition;

//Out variables
out vec3 vColor;

void main()
{
	gl_Position = vec4(vPosition+inPosition,1.0);
	vColor = vec3(tan(vPosition.x+inPosition.x)*(vPosition+inPosition+0.5));
}