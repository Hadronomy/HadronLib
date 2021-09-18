using System;
using System.Linq;
using HadronLib.Registry;
using NUnit.Framework;

namespace HadronLib.Tests.Registry
{
    public static class Registry
    {
        [Test]
        public static void Returns_True_If_Software_Installed()
        {
            var isUnityInstalled = RegistryTools.IsSoftwareInstalled("Microsoft", out var keyName);
            Console.WriteLine($"The key name of the software is: {keyName}");
            
            Assert.IsTrue(isUnityInstalled);
        }

        [Test]
        public static void Getting_Something_On_Generic_Search()
        {
            var results = RegistryTools.GetSoftwareRegistryPaths("Microsoft");

            Assert.IsTrue(results.Any());
        }
    }
}