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
        public String InstallationPath { get; set; }
        
        public override bool Execute()
        {
            var isInstalled = RegistryTools.IsSoftwareInstalled("Unity", out string keyName);
            var installationPath = WinRegistry.LocalMachine.OpenSubKey(keyName).GetValue("InstallLocation") as string ??
                                   "";
            
            IsInstalled = isInstalled.ToString();
            InstallationPath = installationPath;

            Console.WriteLine("HEEEEEEEEELLO");
            
            return true;
        }
    }
}