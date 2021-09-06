using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using HadronLib.Patterns;

namespace HadronLib.Reflection
{
    public class Mirror<TSubject> : Mirror<TSubject, Mirror<TSubject>>
        where TSubject : class
    {
        
    }

    public class Mirror<TSubject, TSelf> : FluentBuilder<TSubject, TSelf>
    where TSubject : class
    where TSelf : Mirror<TSubject, TSelf>
    {
        protected Assembly Assembly;
        protected Type[] Types;

        public TSelf InferAssembly()
        {
            Assembly = typeof(TSubject).Assembly;
            return (TSelf)this;
        }
        
        public TSelf InferAssembly(out Assembly assembly)
        {
            InferAssembly();
            assembly = Assembly;
            return (TSelf)this;
        }

        public TSelf AssignAssembly(Assembly assembly)
        {
            Assembly = assembly;
            return (TSelf)this;
        }

        public TSelf GetTypesFromAssembly()
        {
            var assemblyTypes = Assembly.GetTypes();
            Types = assemblyTypes;
            return (TSelf)this;
        }

        public TSelf AssignTypes(Type[] types)
        {
            Types = types;
            return (TSelf)this;
        }

        public TSelf Find(Func<IEnumerable<Type>, Type> linqQuerry)
        {
            var enumerableTypes = Types.AsEnumerable();
            var result = linqQuerry(enumerableTypes);
            // TODO: Register findings into the builder
            return (TSelf)this;
        }

        public TSelf Filter(Func<IEnumerable<Type>, IEnumerable<Type>> linqQuerry)
        {
            var enumerableTypes = Types.AsEnumerable();
            var results = linqQuerry(enumerableTypes);
            // TODO: Register findings into the builder
            return (TSelf)this;
        }
        
        public override TSubject Build()
        {
            return base.Build();
        }
    }
}