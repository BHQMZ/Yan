using System;
using System.Collections.Generic;

namespace Battle
{
    public class Entity
    {
        private int _entityId;
        public int entityId => _entityId;

        public Entity(int id)
        {
            _entityId = id;
        }
    }
}