using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConsoleApplication1
{
    internal static class IniParse
    {
        public static ParsedIniFile Parse(string filePath)
        {
            var builder = new IniFileBuilder();
            if (!File.Exists(filePath))
                throw new InvalidFileInput("Problem with file" + filePath);
            
            if (Path.GetExtension(filePath) != ".ini")
                throw new InvalidFileType("Wrong type file" + filePath);

            var lines = File.ReadAllLines((filePath));
            var currentSection = new Dictionary<string, string>();
            string newSection = "";
            RegularForms reg = new RegularForms();
            var firstSection = false;
            foreach (var line in lines)
            {
                if (line == "")
                    continue;
                
                if (reg.CheckValidSection(line))
                {
                    if (firstSection)
                    {
                        builder.AddSection(newSection, currentSection);
                        currentSection = new Dictionary<string, string>();
                    }
                    newSection = line.Trim(new char[] {'[', ']'});
                    firstSection = true;
                }
                else if (line[0] != ';')
                {
                    var keysAndValues = line.Split(new char[] {'=', ';'});
                    var newKey = keysAndValues[0].Replace(" ", "");
                    var newValue = keysAndValues[1].Replace(" ", "");
                    currentSection.Add(newKey, newValue);
                    if (!reg.CheckValidKey(newKey) && !reg.CheckValidValue(newValue))
                        throw new InvalidFileType("Invalid keys or values");
                    if (line == lines[lines.Length - 1])
                        builder.AddSection(newSection, currentSection);
                }
            } 
            return builder.Build();
        }
    }

    internal class ParsedIniFile
    {
        private  Dictionary<string, Dictionary<string, string>> data;

        public ParsedIniFile(Dictionary<string,Dictionary<string,string>> newData)
        {
            data = newData;
        }

        public string GetStringData(string sectionKey, string key)
        {
            if (!data.ContainsKey(sectionKey))
            {
                throw new InvalidSection("No section");
            }

            var section = data[sectionKey];
            if (!section.ContainsKey(key))
            {
                throw new WrongFormat("Key Not Found");
            }

            return section[key];
        }

        public int GetIntData(string sectionKey, string key)
        {
            var value = GetStringData(sectionKey, key);
            if (!int.TryParse(value, out var castedValue))
                throw new WrongFormat("Invalid type");
            return castedValue;
        }
        public float GetFloatData(string sectionKey, string key)
        { 
            var value = GetStringData(sectionKey, key);
            if (!float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var castedValue))
                throw new WrongFormat("Invalid type");
            return castedValue;
        }
    }

    internal class IniFileBuilder
    {
        public IniFileBuilder()
        {
            data = new Dictionary<string, Dictionary<string, string>>();
        }

        private Dictionary<string, Dictionary<string, string>> data;
        

        public void AddSection(string sectionName, Dictionary<string, string> keys)
        {
            data.Add(sectionName, keys);
        }

        public ParsedIniFile Build()
        {
            return new ParsedIniFile(data);
        }
    }
}