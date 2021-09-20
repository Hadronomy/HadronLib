using System;
using System.Linq;
using HadronLib.Registry;
using Xunit;

namespace HadronLib.Tests.Registry
{
    public static class Registry
    {
        [Fact]
        public static void Returns_True_If_Software_Installed()
        {
            var isUnityInstalled = RegistryTools.IsSoftwareInstalled("Microsoft", out var keyName);
            Console.WriteLine($"The key name of the software is: {keyName}");
            
            Assert.True(isUnityInstalled);
        }

        [Fact]
        public static void Getting_Something_On_Generic_Search()
        {
            var results = RegistryTools.GetSoftwareRegistryPaths("Microsoft");

            Assert.True(results.Any());
        }
    }
}