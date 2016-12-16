﻿using System;
using System.Text;

namespace Malina.DOM
{
    [Serializable]
    public abstract class Node
    {
        // Fields
        private string _name;
        private Node _parent;
        public SourceLocation start;
        public SourceLocation end;

        public virtual string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        // Methods
        public abstract void Accept(IDomVisitor visitor);
        public virtual void AppendChild(Node child)
        {
            throw new NotSupportedException(new StringBuilder("Cannot add ").Append(child.GetType().Name).Append(" in ").Append(GetType().Name).ToString());
        }

        internal void InitializeParent(Node parent)
        {
            _parent = parent;
        }

        // Properties
        public Node Parent => _parent;
    }
}
