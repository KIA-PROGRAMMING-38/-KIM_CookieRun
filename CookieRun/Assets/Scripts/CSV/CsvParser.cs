using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;

static class CsvParser
{
    private static CsvConfiguration s_config;
    static CsvParser()
    {
        s_config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine
        };
    }

    public static List<T> Parse<T>(string filePath) where T : class
    {
        using (var reader = new StreamReader(filePath))
        {
            using (var csv = new CsvReader(reader, configuration: s_config))
            {
                var records = csv.GetRecords<T>();

                return records.ToList<T>();
            }
        }
    }

    public static List<T> Parse<T>(TextAsset textAsset) where T : class
    {
        return ParseFromString<T>(textAsset.text);
    }

    public static List<T> ParseFromString<T>(string text) where T : class
    {
        using (var reader = new StringReader(text))
        {
            using (var csv = new CsvReader(reader, configuration: s_config))
            {
                var records = csv.GetRecords<T>();

                return records.ToList<T>();
            }
        }
    }
}