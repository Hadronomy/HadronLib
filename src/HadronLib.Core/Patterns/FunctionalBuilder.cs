using System;
using System.Collections.Generic;
using System.Linq;

namespace HadronLib.Patterns
{
    /// <summary>
    /// Implements basic Functional Builder functionality
    /// </summary>
    /// <typeparam name="TSubject">Type of what the functional builder is trying to build</typeparam>
    /// <typeparam name="TSelf">Type of the inheriting class</typeparam>
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> _actions =
            new List<Func<TSubject, TSubject>>();

        /// <summary>
        /// Makes the builder schedule an action
        /// </summary>
        /// <remarks>
        /// On a functional builder, actions are only executed on <see cref="Build"/>
        /// </remarks>
        /// <param name="action"></param>
        /// <returns></returns>
        public TSelf Do(Action<TSubject> action)
            => AddAction(action);
        public TSubject Build()
            => _actions.Aggregate(new TSubject(), (p, f) => f(p));
        
        private TSelf AddAction(Action<TSubject> action)
        {
            _actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }
}