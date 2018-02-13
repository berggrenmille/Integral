namespace IntegralEngine
{
    public class Mesh : Component
    {
        public RawModel model;
        public MeshTexture texture;
        public Mesh(RawModel _model, MeshTexture _texture)
        {
            model = _model;
            texture = _texture;
        }
    }
}