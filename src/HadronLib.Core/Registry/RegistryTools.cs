using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using WinRegistry = Microsoft.Win32.Registry;

namespace HadronLib.Registry
{
    /// <summary>
    /// Collection of registry related helper functions
    /// </summary>
    public static class RegistryTools
    {
        public static bool IsSoftwareInstalled(string softwareName, out string s_KeyName)
        {
            string displayName;

            string registryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = WinRegistry.LocalMachine.OpenSubKey(registryKeyPath);

            if (key != null)
            {
                foreach (var subKey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.ToLower().Contains(softwareName.ToLower()))
                    {
                        s_KeyName = subKey.ToString();
                        return true;
                    }
                }
            }

            registryKeyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = WinRegistry.LocalMachine.OpenSubKey(registryKeyPath);

            if (key != null)
            {
                foreach (var subKey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.ToLower().Contains(softwareName.ToLower()))
                    {
                        s_KeyName = subKey.ToString();
                        return true;
                    }
                }
            }

            s_KeyName = null;
            return false;
        }

        public static IEnumerable<KeyValuePair<string, string>> GetSoftwareRegistryPaths(string searchQuerry)
        {
            string displayName;
            string registryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = WinRegistry.LocalMachine.OpenSubKey(registryKeyPath);

            if (key != null)
            {
                foreach (var subKey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.ToLower().Contains(searchQuerry.ToLower()))
                    {
                        yield return new KeyValuePair<string, string>(displayName, subKey.ToString());
                    }
                }
            }
            
            registryKeyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = WinRegistry.LocalMachine.OpenSubKey(registryKeyPath);

            if (key != null)
            {
                foreach (var subKey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.ToLower().Contains(searchQuerry.ToLower()))
                    {
                        yield return new KeyValuePair<string, string>(displayName, subKey.ToString());
                    }
                }
            }
        }
        
        public static IEnumerable<KeyValuePair<string, string>> GetSoftwarePropertiesByPath(string registryPath)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<KeyValuePair<string, string>> GetSoftwarePropertiesByName(string softwareName)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> GetSoftwareProperty()
        {
            throw new NotImplementedException();
        }
    }
}