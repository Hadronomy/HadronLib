using System.Reflection;

namespace HadronLib.Reflection
{
    public interface IMirrorWithoutAssembly
    {
        IMirrorWithoutTypes WithinAssembly(Assembly assembly);
    }
}