﻿using System;

namespace Malina.DOM
{
    [Serializable]
    public abstract class Entity : Node
    {
        // Methods
        protected Entity()
        {
        }

        public override void Assign(Node node)
        {
            base.Assign(node);
            Entity entity = node as Entity;
            this.Name = entity.Name;
        }
    }


}