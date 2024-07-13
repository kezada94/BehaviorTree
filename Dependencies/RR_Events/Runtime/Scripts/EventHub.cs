using System;
using System.Collections.Generic;

namespace RR.Events
{
    public class EventHub : IEventHub
    {
        private Dictionary<Type, Delegate> _eventMap;

        public EventHub()
        {
            _eventMap = new Dictionary<Type, Delegate>();
        }

        public void Subscribe<T>(T callback) where T : Delegate
        {
            if (!_eventMap.TryGetValue(typeof(T), out Delegate publishers))
            {
                _eventMap.Add(typeof(T), null);
            }
            
            Delegate combinedPublishers = Delegate.Combine(publishers, callback);
            _eventMap[typeof(T)] = combinedPublishers;
        }

        public void Unsubscribe<T>(T callback) where T : Delegate
        {
            if (!_eventMap.TryGetValue(typeof(T), out Delegate publishers))
            {
                return;
            }

            Delegate removedPublishers = Delegate.Remove(publishers, callback);
            _eventMap[typeof(T)] = removedPublishers;
        }

        public T Publisher<T>() where T : Delegate
        {
            if (!_eventMap.TryGetValue(typeof(T), out Delegate publishers))
            {
                return null;
            }

            return (publishers as T);
        }
    }
}
