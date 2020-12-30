using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace Game_Stats_Tracker
{
    class appSetup
    {
        private Dictionary<string, string> keys;
        private Dictionary<string, string> lookupKeys;

        public appSetup()
        {
            keys = new Dictionary<string, string>();
            lookupKeys = new Dictionary<string, string>() { { "steamAPIKey", "steam" }, { "testName", "internalTestName" }, { "otherTest", "yesTestOther" } };
        }
        public void loadConfig()
        {
            // Read and store keys
            // ToDo: Maybe use a Resource file instead?
            if (File.Exists(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"data\keys.xml")))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"data\keys.xml"));
                XmlNode keyNode = doc.SelectSingleNode("/APIKeys");

                foreach (KeyValuePair<string, string> item in lookupKeys)
                {
                    string key = keyNode[item.Key].InnerText;
                    keys.Add(item.Value, key);

                }
            }
            else
            {
                // Create App.config file from defaults
            }
        }

        public string getKey(string name)
        {
            return keys[name];
        }
    }
}