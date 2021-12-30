using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace ExempleFor3Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginLoadContext context = new PluginLoadContext("DynamicLibForLab.dll", "milib.so");

            Assembly assembly = context.LoadFromAssemblyName(new AssemblyName("DynamicLibForLab"));

            object obj = assembly.CreateInstance("DynamicLibForLab.Calc");

            MethodInfo method = obj?.GetType().GetMethod("Do");

            method?.Invoke(obj, null);
        }
    }

    public sealed class PluginLoadContext : AssemblyLoadContext
    {
        private readonly string _managedPath;
        private readonly string _unmanagedPath;

        public PluginLoadContext(string lib, string unLib)
        {
            _managedPath = Path.Combine(Directory.GetCurrentDirectory(), lib);
            _unmanagedPath = Path.Combine(Directory.GetCurrentDirectory(), unLib);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            if (_managedPath.Contains(assemblyName.Name ?? string.Empty))
            {
                if (File.Exists(_managedPath))
                {
                    return LoadFromAssemblyPath(_managedPath);
                }
            }

            return default;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            if (_managedPath.Contains(_unmanagedPath))
            {
                if (File.Exists(_unmanagedPath))
                {
                    return LoadUnmanagedDllFromPath(_unmanagedPath);
                }
            }

            return IntPtr.Zero;
        }
    }
}