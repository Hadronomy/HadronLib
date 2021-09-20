using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using WinRegistry = Microsoft.Win32.Registry;
using HadronLib.Registry;

namespace HadronLib.Tasks
{
    public class IsUnityInstalledTask : Task
    {
        [Output]
        public String IsInstalled { get; set; }
        [Output]
        public String RegistryKeyName { get; set; }
        
        
        public override bool Execute()
        {
            var isInstalled = RegistryTools.IsSoftwareInstalled("Unity 2020", out string keyName);

            IsInstalled = isInstalled.ToString();
            RegistryKeyName = keyName ?? "";

            return true;
        }
    }
}