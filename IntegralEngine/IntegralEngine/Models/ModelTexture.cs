using System.Collections.Generic;
using OpenTK.Graphics.ES10;

namespace IntegralEngine
{
    public class MeshTexture
    {
        private static List<int> textures;

        private int textureID; //keeps track of opengl assigned id

        public MeshTexture(int id)
        {
            textureID = id;
        }

        public int GetID()
        {
            return textureID;
        }

        public static void Cleanup()
        {
            foreach (int text in textures)
            {
                   GL.DeleteTextures(textures.Count, textures.ToArray());
            }
        }
    }
}