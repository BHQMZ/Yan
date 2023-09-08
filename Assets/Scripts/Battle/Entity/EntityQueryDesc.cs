using System;
using System.Linq;

namespace Battle
{
    public class EntityQueryDesc
    {
        public Type[] All;
        public Type[] Any;
        public Type[] None;

        private int _key = -1;

        public int GetKey()
        {
            if (_key > 0)
            {
                return _key;
            }
            var key = 0;
            if (All is {Length: > 0})
            {
                key = HashCode.Combine(key, "All");
                key = All.Aggregate(key, (current, type) => HashCode.Combine(current, type.GetHashCode()));
            }

            if (Any is {Length: > 0})
            {
                key = HashCode.Combine(key, "Any");
                key = Any.Aggregate(key, (current, type) => HashCode.Combine(current, type.GetHashCode()));
            }

            if (None is {Length: > 0})
            {
                key = HashCode.Combine(key, "None");
                key = None.Aggregate(key, (current, type) => HashCode.Combine(current, type.GetHashCode()));
            }

            _key = key;
            return key;
        }
    }
}