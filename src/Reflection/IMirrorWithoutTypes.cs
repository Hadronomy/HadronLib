using System;

namespace HadronLib.Reflection
{
    public interface IMirrorWithoutTypes
    {
        IMirrorWithTypes GetAllAssemblyTypes();
        IMirrorWithTypes GetAllChildTypes(Type parentType);
        IMirrorWithTypes AssignTypes(Type[] types);
    }
}