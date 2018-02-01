namespace IntegralEngine.Messaging
{
    public enum MessageType
    {
        UPDATE = 0,
        DELAYED_UPDATE,
        RENDER,
        INIT,
        EARLY_INIT,
        CLEANUP,
        EXIT,
        NUM_MSGTYPES
    }
}