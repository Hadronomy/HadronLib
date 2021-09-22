using System;
using System.Linq;
using System.Text.RegularExpressions;
using HadronLib.Registry;
using Xunit;

namespace HadronLib.Tests.Registry
{
    public static class Registry
    {
        [Fact]
        public static void Returns_True_If_Software_Installed()
        {
<<<<<<< HEAD
            var isUnityInstalled = RegistryTools.IsSoftwareInRegistry("Microsoft", out var keyName, out var displayName);
            Console.WriteLine($"The key name of the software is: {keyName}");
            
            Assert.True(isUnityInstalled);
=======
            var isUnityInstalled = RegistryTools.IsSoftwareInRegistry("Unity", out var keyName, out var displayName);

            //TODO: Implement mocking or any other system that makes this test more reliant
            Assert.False(isUnityInstalled);
>>>>>>> bc59e7ae54cecf9da97fce87016c3d5b65f89878
        }

        [Fact]
        public static void Getting_Something_On_Generic_Search()
        {
            var results = RegistryTools.GetSoftwareRegistryPaths(new Regex("^Microsoft"));

            Assert.True(results.Any());
        }
    }
}