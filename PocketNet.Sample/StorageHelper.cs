using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.Sample
{
    public static class StorageHelper
    {
        public static void Save(string key, string value)
        {
            var storage = IsolatedStorageSettings.ApplicationSettings;

            if (!storage.Contains("PocketNet_" + key))
            {
                storage.Add("PocketNet_" + key, value);
                storage.Save();
            }
            else
                throw new ArgumentException("Key exists already");
        }

        public static string Retrieve(string key)
        {
            var storage = IsolatedStorageSettings.ApplicationSettings;
            string result;

            storage.TryGetValue("PocketNet_" + key, out result);

            return result;
        }
    }
}