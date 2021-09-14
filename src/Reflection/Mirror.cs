using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using HadronLib.Patterns;

namespace HadronLib.Reflection
{
    public sealed class Mirror : IMirrorWithoutAssembly, IMirrorWithoutTypes, IMirrorWithTypes
    {
        private class InvalidTypeException : Exception
        {
            public InvalidTypeException(string message) : base(message) {}
        }

        private Type _result;

        private Type Result
        {
            get => _result;
            set => _result = value;
        }

        private Lazy<List<Type>> _results = new Lazy<List<Type>>();

        private List<Type> Results
        {
            get => _results.Value;
            set => _results = new Lazy<List<Type>>(() => value);
        }
        
        private Assembly Assembly;
        private Type[] Types;

        public static IMirrorWithoutAssembly New => new Mirror();

        public IMirrorWithoutTypes WithinAssembly(Assembly assembly)
        {
            Assembly = assembly;
            return this;
        }

        public IMirrorWithTypes GetAllAssemblyTypes()
        {
            var assemblyTypes = Assembly.GetTypes();
            Types = assemblyTypes;
            return this;
        }

        public IMirrorWithTypes GetAllChildTypes(Type parentType)
        {
            var assemblyTypes = Assembly.GetTypes();
            var enumerable = assemblyTypes.AsEnumerable();
            var filteredEnum = enumerable.Where(type => parentType.IsAssignableFrom(type) && parentType != type);
            Types = filteredEnum.ToArray();
            return this;
        }

        public IMirrorWithTypes AssignTypes(Type[] types)
        {
            Types = types;
            return this;
        }

        public IMirrorWithTypes Find(Func<IEnumerable<Type>, Type> linqQuerry)
        {
            var enumerableTypes = Types.AsEnumerable();
            var result = linqQuerry(enumerableTypes);
            Result = result;
            return this;
        }

        public IMirrorWithTypes Filter(Func<IEnumerable<Type>, IEnumerable<Type>> linqQuerry)
        {
            var enumerableTypes = Types.AsEnumerable();
            var results = linqQuerry(enumerableTypes);
            Results = results.ToList();
            return this;
        }

        public Type BuildType()
        {
            return Result;
        }

        public List<Type> BuildTypes()
        {
            return Results;
        }


    }
}