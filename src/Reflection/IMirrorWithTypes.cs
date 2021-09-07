using System;
using System.Collections.Generic;

namespace HadronLib.Reflection
{
    public interface IMirrorWithTypes
    {
        IMirrorWithTypes Find(Func<IEnumerable<Type>, Type> linqQuerry);
        IMirrorWithTypes Filter(Func<IEnumerable<Type>, IEnumerable<Type>> linqQuerry);

        Type BuildType();
        List<Type> BuildTypes();
    }
}