using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    public dialogueData DialogueData = new dialogueData();

    #region arrayClasses
    public fs_DialogueALines fsdialogueA = new fs_DialogueALines();
    public fb_DialogueALines fbdialogueA = new fb_DialogueALines();
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

    public void LoadFS()
    {
        string json = ReadFromFile(file);
        //Debug.Log(json);

        fsdialogueA = JsonUtility.FromJson<fs_DialogueALines>(json);
        //Debug.Log(fsdialogueA.fsDialogueALines[0].characterNickname);
        DialogueManager.Instance.ReadDataOutOfArray(fsdialogueA.fsDialogueALines, DialogueManager.Instance.Fin_SageList);

        //fbdialogueA = JsonUtility.FromJson<fb_DialogueALines>(json);        
        //DialogueManager.Instance.ReadDataOutOfArray(fbdialogueA.fbDialogueALines, DialogueManager.Instance.Fin_BotList);

    }

    public void LoadFB()
    {
        string json = ReadFromFile(file);
        //Debug.Log(json);

        fbdialogueA = JsonUtility.FromJson<fb_DialogueALines>(json);
        //Debug.Log(fbdialogueA.fbDialogueALines[0].characterNickname);
        DialogueManager.Instance.ReadDataOutOfArray(fbdialogueA.fbDialogueALines, DialogueManager.Instance.Fin_BotList);

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
        return Path.Combine(Application.dataPath,"Files/Dialog", FileName);
    }    
}
