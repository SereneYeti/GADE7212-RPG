using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class dialogueData 
{
    public dialogueData()
    { }
    public string characterNickname;
    //{
    //    get { return CharacterNickname; }
    //    set { CharacterNickname = value; }
    //}
    //private string CharacterNickname;

    public string dialogueSequence;
    //{
    //    get { return DialogueSequence; }
    //    set { DialogueSequence = value; }
    //}
    //private string DialogueSequence;

    public string nextDialogueSequence;

    public string reqInv;

    public string dialogueChoice;

    public int currentLineNumber;
    //{
    //    get { return LineNumber; }
    //    set { LineNumber = value; }
    //}
    //private int LineNumber;

    public int endTalkArrPos;    

    public string[] characterLines;
    
    //    {
    //        get { return CharacterLines; }
    //        set { CharacterLines = value; }
    //    }
    //    private string[] CharacterLines;
}
