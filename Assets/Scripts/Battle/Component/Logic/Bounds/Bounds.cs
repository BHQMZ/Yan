using System.Collections.Generic;

namespace Battle
{
    public class Bounds : Component
    {
        public EntityQuery Query;
        public List<int> EntityList = new();
    }
}