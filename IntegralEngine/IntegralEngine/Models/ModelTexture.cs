namespace IntegralEngine
{
    public class MeshTexture
    {
        private int textureID; //keeps track of opengl assigned id

        public MeshTexture(int id)
        {
            textureID = id;
        }

        public int GetID()
        {
            return textureID;
        }
    }
}