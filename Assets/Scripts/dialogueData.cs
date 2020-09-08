using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class dialogueData 
{
    public string CharacterNickname
    {
        get { return characterNickname; }
        set{ characterNickname = value; }
    }
    private string characterNickname;

    public string DialogueSequence
    {
        get { return dialogueSequence; }
        set { dialogueSequence = value; }
    }
    private string dialogueSequence;

    public int LineNumber
    {
        get { return lineNumber; }
        set { lineNumber = value; }
    }
    private int lineNumber;

    public string[] CharacterLines
    {
        get { return characterLines; }
        set { characterLines = value; }
    }
    private string[] characterLines;
}
