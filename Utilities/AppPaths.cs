using System;
using System.IO;

namespace ProKS1.Utilities
{
    public static class AppPaths
    {
        public static string DataDir
        {
            get
            {
                var dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "ProKS1");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string DataFile(string fileName) => Path.Combine(DataDir, fileName);
    }
}
