namespace IntegralEngine
{
    public class Game
    {
        public bool isLoaded = false;

        public virtual void Load()
        {
            isLoaded = true;
        }

        public virtual void Update()
        {
        }

        public virtual void Init()
        {
            
        }
    }
}