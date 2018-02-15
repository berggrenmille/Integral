
using IntegralEngine.Messaging;
using IntegralEngine.TestGame;


namespace IntegralEngine
{
    public class Application : IMessageObserver
    {
        private Game game;
        public void Init()
        {
            game = new TestScene();
            game.Load();
            game.Init();
        }

        public void Update()
        {
            if (game.isLoaded)
                game.Update();
        }

        public void Cleanup()
        {
            RawModel.Cleanup();
            MeshTexture.Cleanup();
        }

        public void OnMessage(Message message)
        {
            switch (message.type)
            {
                case MessageType.INIT:
                    Init();
                    break;
                case MessageType.UPDATE:
                    Update();
                    break;
                case MessageType.CLEANUP:
                    Cleanup();
                    break;

                    
            }
        }
    }
}