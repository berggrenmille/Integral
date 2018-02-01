#version 430 core

in vec3 vColor;
out vec4 color;

void main()
{
	color = vec4(vColor.x+0.5,vColor.y+0.5,vColor.z+0.5,1.0);
}