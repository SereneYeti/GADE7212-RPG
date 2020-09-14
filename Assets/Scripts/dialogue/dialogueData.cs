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

    public string interactingID;

    public string characterNickname;

    public string dialogueSequence;
    //{
    //    get { return CharacterNickname; }
    //    set { CharacterNickname = value; }
    //}
    //private string CharacterNickname;    

    public string reqInv;

    public int lineID;
    //{
    //    get { return LineNumber; }
    //    set { LineNumber = value; }
    //}
    //private int LineNumber;

    public int endTalkPos;    

    public string characterLine;

    public int[] possibleResponses;

    //    {
    //        get { return CharacterLines; }
    //        set { CharacterLines = value; }
    //    }
    //    private string[] CharacterLines;
    public override string ToString()
    {
        return characterNickname + ": " + characterLine;
    }
}

public class readSage2000Lines : dialogueData
{   //class used to read out the individual json dialogue data classes from the base json array used to store them
    public dialogueData[] sage2000Lines;
}
public class readFinThePhoneLines : dialogueData
{   //class used to read out the individual json dialogue data classes from the base json array used to store them
    public dialogueData[] FinThePhoneLines;
}

public class readSocialBotLines : dialogueData
{   //class used to read out the individual json dialogue data classes from the base json array used to store them
    public dialogueData[] SocialBotLines;
}