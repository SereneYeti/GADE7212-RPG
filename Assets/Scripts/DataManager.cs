using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    public dialogueData dialogueData;
    private string file = "baseTest.json";
    public void Save()
    {
        string json = JsonUtility.ToJson(dialogueData);
        WriteToFile(file, json);
    }

    public void Load()
    {
        dialogueData = new dialogueData();
        string json = ReadFromFile(file);
        Debug.Log(json);
        dialogueData.CharacterNickname = "b";
        //JsonUtility.FromJson<dialogueData>(json);
        JsonUtility.FromJsonOverwrite(json, dialogueData);
        Debug.Log(dialogueData.CharacterNickname);
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);

        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);

        using(StreamWriter streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(json);
        }
    }

    private string ReadFromFile(string fileName) 
    {
        string path = GetFilePath(fileName);
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found");

            return "";
        }
    }

    private string GetFilePath(string FileName)
    {
        return Path.Combine(Application.persistentDataPath, FileName);
    }
}
