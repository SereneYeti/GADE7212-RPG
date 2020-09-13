﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public MyLinkedList<dialogueData> Sage2000Dialogue = new MyLinkedList<dialogueData>();

    public int sNumLines = 3;

    public void ReadDataOutOfArray(dialogueData[] dialogues)
    {
        foreach (dialogueData d in dialogues)
        {
            DialogueManager.Instance.Sage2000Dialogue.Add(d);
        }

    }
}


