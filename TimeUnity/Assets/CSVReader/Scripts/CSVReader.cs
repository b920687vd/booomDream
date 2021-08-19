using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace TimeUnity.Utils
{
    public class CSVReader
    {
        public static string FillPath = Application.dataPath;
        public CSVReader()
        {
            //...
        }

        protected string[][] m_csvData;
        protected Dictionary<string, int> keys;
        public int Length
        {
            get
            {
                return m_csvData.Length;
            }
        }

        public void ReadFile(string path)
        {
            m_csvData = new string[0][];
            string fillPath = CSVReader.FillPath + path;
            string[] lines = new string[] { };
            try
            {
                lines = File.ReadAllLines(fillPath, Encoding.UTF8);
            }
            catch
            {
                Debug.LogError("No File: " + path);
            }

            m_csvData = new string[lines.Length - 1][];
            for (int i = lines.Length - 1; i >= 1; i--)
            {
                m_csvData[i - 1] = lines[i].Split(',');
            }
            keys = new Dictionary<string, int>();
            string[] keyLine = lines[0].Split(',');
            for (int i = 0; i < keyLine.Length; i--)
            {
                keys.Add(keyLine[i], i);
            }
        }

        public string GetValue(string key, int index)
        {
            if (m_csvData == null || m_csvData.Length == 0)
                return null;
            if (!keys.ContainsKey(key))
                return null;
            return m_csvData[keys[key]][index];
        }
    }
}