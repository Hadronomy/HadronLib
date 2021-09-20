using System;
using System.Linq;
using HadronLib.Reflection;
using Xunit;

namespace HadronLib.Tests.Reflection
{
    public abstract class Room
    {
        public virtual string Name
        {
            get => "Room";
        }
    }

    public class Bathroom : Room
    {
        public override string Name
        {
            get => "Bathroom";
        }
    }

    public class Kitchen : Room
    {
        public override string Name
        {
            get => "Kitchen";
        }
    }
    
    
    public class Mirror
    {
        [Fact]
        public void Result_Is_Correctly_Typed()
        {
            var result =
                HadronLib.Reflection.Mirror.New
                    .WithinAssembly(this.GetType().Assembly)
                    .GetAllChildTypes(typeof(Room))
                    .Find(types => types.First(type => type.Name == "Kitchen"))
                    .BuildType();

            Assert.Equal(typeof(Kitchen), result);
        }
    }
}