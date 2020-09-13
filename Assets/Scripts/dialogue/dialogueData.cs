using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class dialogueData 
{
    public dialogueData()
    { }

    public string characterID;

    public string characterNickname;
    //{
    //    get { return CharacterNickname; }
    //    set { CharacterNickname = value; }
    //}
    //private string CharacterNickname;    

    public string reqInv;

    public string lineID;
    //{
    //    get { return LineNumber; }
    //    set { LineNumber = value; }
    //}
    //private int LineNumber;

    public string endTalkPos;    

    public string characterLine;

    public string[] possibleResponses;
    
    //    {
    //        get { return CharacterLines; }
    //        set { CharacterLines = value; }
    //    }
    //    private string[] CharacterLines;
}

public class readLines : dialogueData
{   //class used to read out the individual json dialogue data classes from the base json array used to store them
    public dialogueData[] sage2000Lines;
}