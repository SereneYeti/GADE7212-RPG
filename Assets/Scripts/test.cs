using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class test : MonoBehaviour
{
    public DataManager dataManager;
    bool save = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //dataManager.dialogueData = new dialogueData();
        //dataManager.dialogueData.CharacterNickname = "Fred";
        //dataManager.dialogueData.CharacterLines = new string[5];
        //dataManager.dialogueData.LineNumber = 0;
        //dataManager.dialogueData.DialogueSequence = "a";
        //dataManager.Save();
        //dataManager.Load();
        Debug.Log(dataManager.dialogueData.CharacterNickname);
        save = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (save && count != 1)
        {
            count = 1;
            dataManager.Load();
        }
    }
}
