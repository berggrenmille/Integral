using System;
using IntegralEngine.TestScripts;

namespace IntegralEngine.TestGame
{
    public class TestScene : Game
    {
        private float[] v1 =
        {
            -0.5f, 0.5f, 0,
            -0.5f, -0.5f, 0,
            0.5f, -0.5f, 0,
            0.5f, 0.5f, 0
        };

        private int[] indices =
        {
            0, 1, 3,
            3, 1, 2
        };

        private float[] textureCoords =
        {
            0, 0,
            0, 1,
            1, 1,
            1, 0
        };
        public override void Load()
        {
            Entity cam = EntityFactory.CreateEntity();
            cam.name = "cam";
            cam.AddComponent(new Camera());

            Entity ent = EntityFactory.CreateEntity();
            ent.AddComponent(new Move());
            ent.AddComponent(new MeshRenderer());
            MeshTexture texture = MeshTexture.LoadTexture("Res/Images/bobross.png");
            ent.GetComponent<MeshRenderer>().texturedMesh = new TexturedMesh(RawMesh.LoadToVao(v1,textureCoords, indices), texture);

            
            base.Load();
        }
        
    }
}