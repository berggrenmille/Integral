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
        public override void Load()
        {
            Entity ent = EntityFactory.CreateEntity();
            ent.AddComponent(new Move());
            ent.GetComponent<MeshRenderer>().mesh = new Mesh(RawModel.LoadToVao(v1,indices), null);
            base.Load();
        }
        
    }
}