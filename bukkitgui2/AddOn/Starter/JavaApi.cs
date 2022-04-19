﻿// JavaApi.cs in bukkitgui2/bukkitgui2
// Created 2014/02/22
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using Net.Bertware.Bukkitgui2.Core;
using Net.Bertware.Bukkitgui2.Core.Configuration;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.AddOn.Starter
{
	internal static class JavaApi
	{
		private static Boolean _initialized;

		private static Dictionary<String, String> _javaPaths;

		/// <summary>
		///     Initialize the class, check available versions and paths
		/// </summary>
		public static void Initialize()
		{
			if (_initialized) return;
			_javaPaths = new Dictionary<String, string>();
			try
			{
				RegistryKey javaroot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\JavaSoft");
				if (Share.Is64Bit)
				{
					Logger.Log(LogLevel.Info, "JavaApi", "Getting Java location for 64bit machine");
					RegistryKey javaroot32 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\JavaSoft");
					DetectJavaFromRegistry(javaroot, true);
					DetectJavaFromRegistry(javaroot32);
				}
				else
				{
					Logger.Log(LogLevel.Info, "JavaApi", "Getting Java location for 32bit machine");
					DetectJavaFromRegistry(javaroot);
				}
			}
			catch (Exception)
			{
				Logger.Log(LogLevel.Warning, "JavaApi", "Failed to detect java from registry, falling back to filesystem");
				DetectJavaByFilestructure();
			}

			_initialized = true;
		}

		private static void DetectJavaFromRegistry(RegistryKey rootkey, bool is64Bit = false)
		{
			RegistryKey javaJre = rootkey.OpenSubKey("Java Runtime Environment");
			RegistryKey javaJdk = rootkey.OpenSubKey("Java Development Kit");

			foreach (RegistryKey versionRoot in new[] {javaJre, javaJdk})
			{
				if (versionRoot == null || versionRoot.GetSubKeyNames().Length < 1) continue; // no keys in here

				foreach (string subkey in versionRoot.GetSubKeyNames())
				{
					Match r = Regex.Match(subkey, @"^\d.(\d)$");
					if (r.Success)
					{
						//int runtimeversion = Convert.ToInt32(r.Groups[1].Value);
						RegistryKey subKeyInstance = versionRoot.OpenSubKey(subkey);
						if (subKeyInstance != null)
						{
							if (string.IsNullOrEmpty(subKeyInstance.GetValue("JavaHome").ToString())) continue;
							string path = subKeyInstance.GetValue("JavaHome") + "\\bin\\java.exe";
							SetJavaPath(r.Groups[1].Value, is64Bit, path);
						}
					}
				}
			}
		}


		private static void DetectJavaByFilestructure()
		{
			if (Directory.Exists(ProgramFilesx86() + "\\Java\\"))
			{
				foreach (string dir in Directory.GetDirectories(ProgramFilesx86() + "\\Java\\"))
				{
					if (!File.Exists(dir + "\\bin\\java.exe")) return;
						SetJavaPath(dir, true, dir + "\\bin\\java.exe");
				}
			}

			if (Directory.Exists(ProgramFiles() + "\\Java\\") & Share.Is64Bit)
			{
				foreach (string dir in Directory.GetDirectories(ProgramFiles() + "\\Java\\"))
				{
					if (!File.Exists(dir + "\\bin\\java.exe")) return;
						SetJavaPath(dir, true, dir + "\\bin\\java.exe");
				}
			}
		}


		/// <summary>
		///     Set the java path for a given version
		/// </summary>
		/// <param name="version">the runtime version, between 6 and 9</param>
		/// <param name="is64Bitversion">wether or not this is a 64bit java executable</param>
		/// <param name="path">The path to java.exe. If this file does not exist, the path will not be set</param>
		private static void SetJavaPath(string version, bool is64Bitversion, string path)
		{
			Logger.Log(LogLevel.Info, "JavaApi", "Registering java " + version + " at " + path);
			if (!File.Exists(path))
			{
				Logger.Log(LogLevel.Warning, "JavaApi", "Failed to register java " + version + " at " + path,"File not found");
				return;
			}
			int id = version.GetHashCode()*100 + ((is64Bitversion) ? 64 : 32);
			_javaPaths[version] = path;
			Logger.Log(LogLevel.Info, "JavaApi", "Registered java " + version + " at " + path);
		}


		/// <summary>
		///		Returns all detected java
		/// </summary>
		public static List<String> GetInstalledJava()
        {
			if (_javaPaths == null) Initialize();
			return _javaPaths.Keys.ToList();
		}

		/// <summary>
		///     Get the absolute location of an installed java version
		/// </summary>
		/// <param name="jreVersion">The java version to retrieve</param>
		/// <returns>Returns the absolute path to java.exe</returns>
		public static string GetJavaPath(String jreVersion)
		{
			if (!_initialized)
			{
				Initialize();
			}
			Logger.Log(LogLevel.Info, "JavaApi","Getting Java Path for version " + jreVersion);
			string path;

			if (_javaPaths.ContainsKey(jreVersion))
			{
				path = _javaPaths[jreVersion];
				Logger.Log(LogLevel.Info, "JavaApi", "Using java " + jreVersion + ", path: " + path);
				return path;
			}
			Logger.Log(LogLevel.Warning, "JavaApi", "Java " + jreVersion + " requested but not found!");
			return null;
		}

		/// <summary>
		/// Get the latest available java version on this system, for running small tools (retrieving versions etc)
		/// </summary>
		/// <returns>A full path to java.exe</returns>
		public static string GetIdealJavaPath()
		{
			//int versionnum = 0;
			string path = null;
			foreach (KeyValuePair<String, string> pair in _javaPaths)
			{
				path = pair.Value;
			}
			return path;
		}

		/// <summary>
		///     Check if a java version is 32 bit
		/// </summary>
		/// <param name="version">the version to check</param>
		/// <returns></returns>
		public static bool Is32Bitversion(string version)
		{
			return (version.ToString().ToLower().Contains("x32"));
		}

		private static string ProgramFilesx86()
		{
			if (8 == IntPtr.Size
			    || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
			{
				return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
			}

			return Environment.GetEnvironmentVariable("ProgramFiles");
		}

		private static string ProgramFiles()
		{
			if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ProgramW6432")))
				return (Environment.GetEnvironmentVariable("ProgramW6432"));
			return Environment.GetEnvironmentVariable("ProgramFiles");
		}
	}

}