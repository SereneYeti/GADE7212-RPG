using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public DataManager dataManager;
    bool save = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        //dataManager.Save();
        //dataManager.Load();
        //Debug.Log(dataManager.DialogueData);
        save = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (save && count != 1)
        {

            count = 1;
            dataManager.Load();
            Debug.Log(DialogueManager.Instance.Sage2000Dialogue.Head.Data.characterLines[DialogueManager.Instance.Sage2000Dialogue.Head.Data.currentLineNumber]);
            DialogueManager.Instance.Sage2000Dialogue.Head.Data.currentLineNumber++;
            Debug.Log(DialogueManager.Instance.Sage2000Dialogue.Head.Data.characterLines[DialogueManager.Instance.Sage2000Dialogue.Head.Data.currentLineNumber]);
        }
    }
}
