using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerChoice : MonoBehaviour
{
    public Button btnOption1;
    public Button btnOption2;
    public Button btnOption3;

    public DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        btnOption1.onClick.AddListener(Option1);
        btnOption2.onClick.AddListener(Option3);
        btnOption3.onClick.AddListener(Option2);
    }

    public void Option1()
    {
        DialogueManager.Instance.playerChoice = 0;
        DialogueManager.Instance.playerChosen = true;
        Debug.Log(DialogueManager.Instance.playerChoice);
        Debug.Log("clicked");
        dialogueController.NextDialogue(dialogueController._lineID, dialogueController.tempData.possibleResponses);
    }

    public void Option2()
    {
        DialogueManager.Instance.playerChoice = 1;
        DialogueManager.Instance.playerChosen = true;
        Debug.Log(DialogueManager.Instance.playerChoice);
        Debug.Log("clicked");
    }
    
    public void Option3()
    {
        DialogueManager.Instance.playerChoice = 2;
        DialogueManager.Instance.playerChosen = true;
    }
}
