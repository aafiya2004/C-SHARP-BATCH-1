using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetManagementApp.Utility
{
    internal class DBPropertyUtil
    {
        public static Dictionary<string, string> LoadProperties(string filePath)
        {
            var properties = new Dictionary<string, string>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith("#"))
                    continue;

                var parts = trimmedLine.Split('=', 2);
                if (parts.Length == 2)
                {
                    properties[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return properties;
        }
    }
}

  
