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
            var isUnityInstalled = RegistryTools.IsSoftwareInRegistry("Unity", out var keyName, out var displayName);
            Console.WriteLine($"The key name of the software is: {keyName}");

            Assert.False(isUnityInstalled);
        }

        [Fact]
        public static void Getting_Something_On_Generic_Search()
        {
            var results = RegistryTools.GetSoftwareRegistryPaths(new Regex("^Microsoft"));

            Assert.True(results.Any());
        }
    }
}