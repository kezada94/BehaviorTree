namespace RR.Serialization
{
    [System.Serializable]
    public class ReadonlyVar<T>
    {
        [UnityEngine.SerializeField]
        private T _value;

        public T Value => _value;

        public static implicit operator T(ReadonlyVar<T> v) => v.Value;
    }
}
