namespace IntegralEngine
{
    public class Component
    {
        private static int numComponents = 0;
        public int id = 0;

        public Component()
        {
            id = numComponents++;
        }

        public virtual void UpdateComponent()
        {
            
        }
    }
}