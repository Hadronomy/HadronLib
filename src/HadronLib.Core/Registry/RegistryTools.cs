using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using WinRegistry = Microsoft.Win32.Registry;

namespace HadronLib.Registry
{
    /// <summary>
    /// Collection of registry related helper functions
    /// </summary>
    public static class RegistryTools
    {
        public static bool IsSoftwareInRegistry(Func<string, bool> matchFunction, out string s_KeyName, out string displayName)
        {

            string registryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = WinRegistry.LocalMachine.OpenSubKey(registryKeyPath);

            if (key != null)
            {
                foreach (var subKey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName != null && matchFunction(displayName))
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
                    if (displayName != null && matchFunction(displayName))
                    {
                        s_KeyName = subKey.ToString();
                        return true;
                    }
                }
            }

            s_KeyName = null;
            displayName = null;
            return false;
        }
        
        public static bool IsSoftwareInRegistry(string softwareName, out string s_KeyName, out string displayName)
        {
            return IsSoftwareInRegistry(
                (registryName) => registryName.ToLower().Contains(softwareName),
                out s_KeyName,
                out displayName
            );
        }
        
        public static bool IsSoftwareInRegistry(Regex regex, out string s_KeyName, out string displayName)
        {
            return IsSoftwareInRegistry(
                (registryName) => regex.Match(registryName).Success,
                out s_KeyName,
                out displayName);
        }

        /// <summary>
        /// Returns an enumeration of <see cref="KeyValuePair{TKey, TValue}"/> the Key being the DisplayName
        /// and the value being the keyName/keyPath of the found Software Registries with a Display Name that matched the provided
        /// regex expression
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<string, string>> GetSoftwareRegistryPaths(Regex regex)
        {
            string displayName;
            string registryKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = WinRegistry.LocalMachine.OpenSubKey(registryKeyPath);

            if (key != null)
            {
                foreach (var subKey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName != null && (regex.Match(displayName)?.Success ?? false))
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
                    if (displayName != null && (regex.Match(displayName)?.Success ?? false))
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