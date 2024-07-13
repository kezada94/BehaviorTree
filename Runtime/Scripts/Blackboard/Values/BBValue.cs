using System;

namespace RR.AI
{  
    public readonly struct BBValue<T> : IBBValueBase
    {
        public readonly T value;

        public BBValue(T value)
        {
            this.value = value;
        }

        public static implicit operator BBValue<T>(T val) => new(val);
        public static implicit operator T(BBValue<T> val) => val.value;

        public object ValueAsObject => value;
        public Type ValueType => typeof(T);
    }
}