﻿using System;
using System.Collections.Generic;

namespace IntegralEngine
{

    public static class MessageBus
    {
        private static readonly List<IMessageObserver> observerList = new List<IMessageObserver>();
        public static void Subscribe(IMessageObserver obs)
        {
            observerList.Add(obs);
        }

        public static void Unsubscribe(IMessageObserver obs)
        {
            observerList.Remove(obs);
        }

        public static void SendMessage(Message message, IMessageObserver to)
        {
            to.OnMessage(message);
        }
        public static void SendMessage(Message message)
        {
            foreach (var obs in observerList)
            {
                obs.OnMessage(message);
            }
        }
    }
}