using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    public dialogueData DialogueData = new dialogueData();

    #region arrayClasses
    public readSage2000Lines ReadSage2000Lines = new readSage2000Lines();
    public readFinThePhoneLines ReadFinThePhoneLines = new readFinThePhoneLines();
    #endregion
    public string file
    {
            get { return _file; }
            set { _file = value; }
        
    }
    private string _file = "sage2000.json";
    public void Save()
    {
        string json = JsonUtility.ToJson(DialogueData);
        WriteToFile(_file, json);
    }

    public void Load(string charID)
    {
        string json = ReadFromFile(file);
        //Debug.Log(json);

        if(charID == CharacterIDs.s.ToString())
        {
            ReadSage2000Lines = JsonUtility.FromJson<readSage2000Lines>(json);
            //Debug.Log(ReadLines.sage2000Lines[0].characterNickname);
            DialogueManager.Instance.ReadDataOutOfArray(ReadSage2000Lines.sage2000Lines);
        }
        else if (charID == CharacterIDs.f.ToString())
        {
            ReadFinThePhoneLines = JsonUtility.FromJson<readFinThePhoneLines>(json);
            //Debug.Log(ReadFinThePhoneLines.FinThePhoneLines[0].characterNickname);
            DialogueManager.Instance.ReadDataOutOfArray(ReadFinThePhoneLines.FinThePhoneLines);
        }

        #region Commented out testing
        //DialogueManager.Instance.Sage2000Dialogue.Add(JsonUtility.FromJson<dialogueData>(json));
        //Debug.Log(DialogueManager.Instance.Sage2000Dialogue.Head.Data.characterLine);

        // DialogueManager.Instance.Sage2000Dialogue.Add(JsonUtility.FromJson<dialogueData>(json));
        //Debug.Log(DialogueManager.Instance.Sage2000Dialogue.Tail.Data.characterLine);

        //DialogueData.CharacterNickname = "t";
        //JsonUtility.FromJson<dialogueData>
        //JsonUtility.FromJsonOverwrite(json, DialogueData);

        //dialogueData[dialogueData.Count].Count++;
        #endregion
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
