namespace IntegralEngine.Messaging
{


    public struct Message
    {
        public string data;
        public MessageType type;
        public IMessageObserver entity;
        public Message(MessageType _type, string _data = "", IMessageObserver _entity = null)
        {
            data = _data;
            type = _type;
            entity = _entity;
        }

    }
}