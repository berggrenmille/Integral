using System;
using System.Collections.Generic;

namespace IntegralEngine
{
    public enum MsgEvent
    {
        UPDATE = 0,
        DELAYED_UPDATE,
        RENDER,
        NUM_MSGID
    }
    public struct Msg
    {
        public string data;
        public MsgEvent id;
        public IMsgObserver entity;
        public Msg(string _data = "", MsgEvent _id = 0, IMsgObserver _entity = null)
        {
            data = _data;
            id = _id;
            entity = _entity;
        }
    
    }
    public static class MsgBus
    {
        private static readonly List<IMsgObserver> observerList = new List<IMsgObserver>();
        public static void Subscribe(IMsgObserver obs)
        {
            observerList.Add(obs);
        }

        public static void Unsubscribe(IMsgObserver obs)
        {
            observerList.Remove(obs);
        }

        public static void SendMessage(Msg msg, IMsgObserver to)
        {
            to.OnMsg(msg);
        }
        public static void SendMessage(Msg msg)
        {
            foreach (var obs in observerList)
            {
                obs.OnMsg(msg);
            }
        }
    }
}