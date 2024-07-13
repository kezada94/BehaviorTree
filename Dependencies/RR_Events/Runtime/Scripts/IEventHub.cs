using System;

namespace RR.Events
{
    public interface IEventHub
    {
        void Subscribe<T>(T callback) where T : Delegate;
        void Unsubscribe<T>(T callback) where T : Delegate;
        T Publisher<T>() where T : Delegate;
    }
}
