using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitors.Generic
{
    public interface IVisitor<TToBeVisited, TResult> : IVisitor where TToBeVisited : IVisitable
    {
        TResult Visit(TToBeVisited visited);
    }

    public interface IVisitor
    { }

    public interface IVisitable<TVisitor, TResult> : IVisitable where TVisitor : IVisitor
    {
        TResult Accept(TVisitor visitor);
    }

    public interface IVisitable
    { }

    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}