using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FileNames
{
    sage2000,
    finThePhone,
    socialBot
};
public enum CharacterIDs
{
    s,
    f,
    b
}
public class DialogueManager : MonoBehaviour
{
    #region Singleton Setup
    private static DialogueManager instance;

    public static DialogueManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public MyLinkedList<dialogueData> Sage2000List = new MyLinkedList<dialogueData>();
    public MyLinkedList<dialogueData> FinThePhoneList = new MyLinkedList<dialogueData>();
    public MyLinkedList<dialogueData> SocialBotList = new MyLinkedList<dialogueData>();

    public bool clicked = false;
    public string fileExtention = ".json";
    public void ReadDataOutOfArray(dialogueData[] dialogues)
    {
        foreach (dialogueData d in dialogues)
        {
            if(d.characterID == CharacterIDs.s.ToString())
            {
                Sage2000List.Add(d);
            }
            else if (d.characterID == CharacterIDs.f.ToString())
            {
                FinThePhoneList.Add(d);
            }
            else if (d.characterID == CharacterIDs.b.ToString())
            {
                SocialBotList.Add(d);
            }
        }

    }
}


