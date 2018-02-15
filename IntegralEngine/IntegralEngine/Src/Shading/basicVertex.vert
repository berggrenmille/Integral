#version 430 core 

//Uniform variables
uniform vec3 inPosition;
uniform vec3 inScale;

//Attribute list variables
layout(location = 0) in vec3 vPosition;

//Out variables
out vec3 vColor;

void main()
{
	vec3 vertPos = vec3((vPosition+inPosition)*inScale);
	gl_Position = vec4(vertPos,1.0);
	vColor = vec3(vertPos.x, vertPos.y, vertPos.x);
}