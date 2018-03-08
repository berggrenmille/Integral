using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using System.Drawing;
using System.Drawing.Imaging;
namespace IntegralEngine
{
    public class MeshTexture
    {
        private static List<int> textures = new List<int>();

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
            GL.DeleteTextures(textures.Count, textures.ToArray());
        }



        public static MeshTexture LoadTexture(string file)
        {
            MeshTexture texture = new MeshTexture(GetTexture(file));
            int textureID = texture.GetID();
            textures.Add(textureID);
            return texture;
        }

        private static int GetTexture(string file)
        {
            Bitmap bitmap;
            try
            {
                bitmap = new Bitmap(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("Texture at location: "+file+" does not exist...");
                bitmap = new Bitmap("Res/Images/Error.png");
            }

            int tex;
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);


            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return tex;
        }
    }
}