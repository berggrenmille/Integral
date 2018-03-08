namespace IntegralEngine
{
    public class TexturedMesh : Component
    {
        private RawMesh rawMesh;
        private MeshTexture texture;
        public TexturedMesh(RawMesh _mesh, MeshTexture _texture)
        {
            this.rawMesh = _mesh;
            this.texture = _texture;
        }

        public RawMesh GetRawMesh()
        {
            return rawMesh;
        }

        public MeshTexture GetTexture()
        {
            return texture;
        }
    }
}