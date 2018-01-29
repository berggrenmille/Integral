namespace IntegralEngine
{
    public enum MessageEvent
    {
        UPDATE = 0,
        DELAYED_UPDATE,
        RENDER,
        INIT,
        CLEANUP,
        EXIT,
        NUM_MSGID
    }

    public struct Message
    {
        public string data;
        public MessageEvent id;
        public IMessageObserver entity;
        public Message(string _data = "", MessageEvent _id = 0, IMessageObserver _entity = null)
        {
            data = _data;
            id = _id;
            entity = _entity;
        }

    }
}