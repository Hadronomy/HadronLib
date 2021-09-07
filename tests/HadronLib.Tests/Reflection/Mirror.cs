using System;
using System.Linq;
using HadronLib.Reflection;
using NUnit.Framework;

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
        [Test]
        public void IsResultCorrectlyTyped()
        {
            var result =
                HadronLib.Reflection.Mirror.New
                    .WithinAssembly(this.GetType().Assembly)
                    .GetAllChildTypes(typeof(Room))
                    .Find(types => types.First(type => type.Name == "Kitchen"))
                    .BuildType();

            Assert.AreEqual(typeof(Kitchen), result);
        }
    }
}