#version 430 core

in vec2 passTextCoords;

out vec4 color;

uniform sampler2D textureSampler;

void main(void)
{
	color = texture(textureSampler, passTextCoords);
}