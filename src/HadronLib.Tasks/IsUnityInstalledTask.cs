using System;
using System.Text.RegularExpressions;
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
        
        [Output]
        public String RegistryDisplayName { get; set; }
        
        public override bool Execute()
        {
            var isInstalled = RegistryTools.IsSoftwareInRegistry(
                new Regex("^Unity.*"),
                out string keyName, 
                out var displayName);
            
            IsInstalled = isInstalled.ToString();
            RegistryKeyName = keyName ?? "";
            RegistryDisplayName = displayName ?? "";
            
            return true;
        }
    }
}