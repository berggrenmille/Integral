using IntegralEngine.TestScripts;

namespace IntegralEngine.TestGame
{
    public class TestScene : Game
    {
        public override void Load()
        {
            Entity ent = EntityFactory.CreateEntity();
            ent.AddComponent(new Move());
            base.Load();
        }
        
    }
}