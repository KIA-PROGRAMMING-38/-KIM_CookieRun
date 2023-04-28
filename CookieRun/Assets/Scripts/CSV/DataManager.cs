using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataManager
{
    private static List<JellyCVS> s_jellies;
    public static List<JellyCVS> Jellies => s_jellies;

    static DataManager()
    {
        Init();
    }

    public static void Init()
    {
        TextAsset jellyCsvFile = LoadFile<TextAsset>("Jelly");
        s_jellies = CsvParser.Parse<JellyCVS>(jellyCsvFile);
    }

    const string DATA_FILE_ROOT_DIRECTORY = "Data";
    private static T LoadFile<T>(string filename) where T : UnityEngine.Object
    {
        string filePath = Path.Combine(DATA_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<T>(filePath);
    }

    const string SPRITE_FILE_ROOT_DIRECTORY = "Sprites";
    public static Sprite LoadSprite(string filename)
    {
        string filePath = Path.Combine(SPRITE_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<Sprite>(filePath);
    }
}