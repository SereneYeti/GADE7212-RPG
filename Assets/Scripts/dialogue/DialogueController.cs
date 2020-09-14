using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public DataManager dataManager;

    Image pnlDisplayMaterial;
    public GameObject pnlDisplay;
    public GameObject pnlCharacterName;
    public TextMeshProUGUI txtDisplay;
    public TextMeshProUGUI txtCharacterName;

    public dialogueData tempData;
    dialogueData response = new dialogueData();
    public Button btnOption1;
    public Button btnOption2;
    public Button btnOption3;
    public TextMeshProUGUI txtOption1;
    public TextMeshProUGUI txtOption2;
    public TextMeshProUGUI txtOption3;

    public int _lineID = 0;

    string interactingID;

    int countSage;
    int countSocial;
    public int countFin;
    int speaker;
    public bool ReadLine = false;
    private void Start()
    {
        countSage = 0;
        countFin = 0;
        countSocial = 0;
        speaker = -1;
        //Load Sage2000 json
        dataManager.file = FileNames.sage2000 + DialogueManager.Instance.fileExtention;
        //Debug.Log(dataManager.file);
        dataManager.Load(CharacterIDs.s.ToString());
        //Load FinThePhone json
        dataManager.file = FileNames.finThePhone + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.f.ToString());
        //Load SocialBot json
        dataManager.file = FileNames.socialBot + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.b.ToString());

        //Debug.Log(DialogueManager.Instance.SocialBotList.Head.Data.characterNickname);
        pnlDisplayMaterial = pnlDisplay.GetComponent<Image>();
        tempData = DialogueManager.Instance.FinThePhoneList.Head.Data;
    }

    void ChangeBtnVis(int numChoices, bool vis)
    {
        Debug.Log(numChoices);
        if(numChoices == 1)
        {
            btnOption1.gameObject.SetActive(vis);
        }
        else if (numChoices == 2)
        {
            btnOption1.gameObject.SetActive(vis);
            btnOption3.gameObject.SetActive(vis);
        }
        else if (numChoices == 3)
        {
            btnOption1.gameObject.SetActive(vis);
            btnOption2.gameObject.SetActive(vis);
            btnOption3.gameObject.SetActive(vis);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator waiter()
    {        

        //Wait for 0.5 seconds
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("waited");
        Debug.Log("here");
        
        //Debug.Log(response.possibleResponses[DialogueManager.Instance.playerChoice]);
        //Debug.Log(DialogueManager.Instance.playerChoice);       

    }

    public void NextDialogue(int lineID, int[] posResponeses)
    {
        tempData = DialogueManager.Instance.Sage2000List.Retrive(posResponeses[DialogueManager.Instance.playerChoice]);
        lineID = tempData.lineID;
        response = DialogueManager.Instance.FinThePhoneList.FindNode(DialogueManager.Instance.FinThePhoneList, lineID, interactingID);
        ReadLine = false;
    }

    public void DoDialogue()
    {
        #region FromTestProgram
        dialogueData tempData = new dialogueData();
        bool finished = false;
        if(DialogueManager.Instance.currentInteraction == "s")
        {
            //The speaker variable will be used to determine & switch the speaker. 0 = SAGE & 1 = FIN          
            if (speaker == -1)
            {
                speaker = 0;
                if (countSage == DialogueManager.Instance.Sage2000List.Length) { Debug.Log("this2"); finished = true; speaker = -2; }
            }
            else if (speaker == 0 && !finished)
            {
                pnlDisplayMaterial.color = Color.yellow;
                tempData = DialogueManager.Instance.Sage2000List.Retrive(countSage);
                SetText(tempData.characterNickname, tempData.characterLine);
                NextLine();
                if (ReadLine) { speaker = 1; ReadLine = false; countSage++; }
            }
            else if (speaker == 1 && !finished)
            {
                pnlDisplayMaterial.color = Color.green;
                tempData = DialogueManager.Instance.FinThePhoneList.Retrive(countFin);
                SetText(tempData.characterNickname, tempData.characterLine);
                NextLine();
                if (ReadLine) { speaker = -1; ReadLine = false; countFin++; }
            }
            if (speaker == -2 && finished == true)
            {
                countFin = 0;
                countSage = 0;
                speaker = 0;
                Debug.Log("here");
                pnlDisplay.SetActive(false);
                pnlCharacterName.SetActive(false);
                txtDisplay.gameObject.SetActive(false);
                txtCharacterName.gameObject.SetActive(false);
                DialogueManager.Instance.clicked = false;
            }
        }
        else if (DialogueManager.Instance.currentInteraction == "b")
        {
            //Debug.Log(countFin);
            //The speaker variable will be used to determine & switch the speaker. 0 = SocialBot & 1 = FIN          
            if (speaker == -1)
            {
                speaker = 0;
                Debug.Log(countSocial);
                Debug.Log(DialogueManager.Instance.SocialBotList.Length);
                if (countSocial == DialogueManager.Instance.SocialBotList.Length-1) { Debug.Log("this2"); finished = true; speaker = -2; }
            }
            else if (speaker == 0 && !finished)
            {
                pnlDisplayMaterial.color = Color.red;
                tempData = DialogueManager.Instance.SocialBotList.Retrive(countSocial);
                SetText(tempData.characterNickname, tempData.characterLine);
                NextLine();
                if (ReadLine) { speaker = 1; ReadLine = false; countSocial++; }
            }
            else if (speaker == 1 && !finished)
            {
                pnlDisplayMaterial.color = Color.green;
                tempData = DialogueManager.Instance.FinThePhoneList.Retrive(countFin);
                SetText(tempData.characterNickname, tempData.characterLine);
                NextLine();
                if (ReadLine) { speaker = -1; ReadLine = false; countFin++; }
            }
            if (speaker == -2 && finished == true)
            {
                countFin = 0;
                countSage = 0;
                countSocial = 0;
                speaker = 0;
                Debug.Log("here");
                pnlDisplay.SetActive(false);
                pnlCharacterName.SetActive(false);
                txtDisplay.gameObject.SetActive(false);
                txtCharacterName.gameObject.SetActive(false);
                DialogueManager.Instance.clicked = false;
            }
        }
        #endregion

            #region working on implementing dialogue using all the fields available       

            //interactingID = DialogueManager.Instance.currentInteraction;

            //if(interactingID == "s")
            //{
            //    if(tempData.lineID == 0)
            //    {
            //        tempData = DialogueManager.Instance.Sage2000List.Retrive(_lineID);
            //        _lineID = tempData.lineID;
            //        response = DialogueManager.Instance.FinThePhoneList.FindNode(DialogueManager.Instance.FinThePhoneList, _lineID, interactingID);
            //        SetText(tempData.characterNickname, tempData.characterLine);
            //        ChangeBtnVis(2, true);
            //        (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, _lineID, interactingID);
            //        (txtCharacterName.text, txtOption3.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, -1, interactingID);
            //        int[] tempPosChoice = tempData.possibleResponses;
            //        tempData = DialogueManager.Instance.Sage2000List.FindNode(DialogueManager.Instance.Sage2000List, response.possibleResponses[DialogueManager.Instance.playerChoice], interactingID);
            //        response = DialogueManager.Instance.FinThePhoneList.FindNode(DialogueManager.Instance.FinThePhoneList, tempPosChoice[DialogueManager.Instance.playerChoice], interactingID);
            //    }
            //    else
            //    {
            //        if(!ReadLine)
            //        {
            //            SetText(tempData.characterNickname, tempData.characterLine);
            //            ChangeBtnVis(tempData.possibleResponses.Length, true);
            //            if (tempData.possibleResponses.Length == 1)
            //            {
            //                (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[0], interactingID);
            //                //lineID++;

            //            }
            //            else if (tempData.possibleResponses.Length == 2)
            //            {
            //                (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[0], interactingID);
            //                (txtCharacterName.text, txtOption3.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[1], interactingID);
            //                //lineID++;
            //            }
            //            else if (tempData.possibleResponses.Length == 3)
            //            {
            //                (txtCharacterName.text, txtOption1.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[0], interactingID);
            //                (txtCharacterName.text, txtOption2.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[2], interactingID);
            //                (txtCharacterName.text, txtOption3.text) = DialogueManager.Instance.FinThePhoneList.FindLine(DialogueManager.Instance.FinThePhoneList, tempData.possibleResponses[1], interactingID);
            //                //lineID++;
            //            }

            //            if (Input.GetKeyDown(KeyCode.Mouse0))
            //            {
            //                NextLine();
            //            }

            //            if (ReadLine == true)
            //            {
            //                //txtOption1.text = "";
            //                //txtOption2.text = "";
            //                //txtOption3.text = "";
            //                //Debug.Log(tempData.possibleResponses[0]);
            //                //StartCoroutine(waiter());
            //                NextDialogue(_lineID, tempData.possibleResponses);
            //            }
            //        }

            //    }
            //}
            //else if (interactingID == "b")
            //{
            //    if (tempData == null)
            //    {
            //        tempData = DialogueManager.Instance.SocialBotList.Retrive(_lineID);
            //        _lineID = tempData.lineID;
            //    }


            //}

            #endregion
    }

    public void SetText(string characterName, string characterLine)
    {
        txtCharacterName.text = characterName;
        txtDisplay.text = characterLine;
    }

    public void NextLine()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("hi");
            //if (speaker == 0) speaker = 1; else speaker = 0;
            if (ReadLine) { ReadLine = false; }
            else if (!ReadLine) { ReadLine = true; ; }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.clicked)
        {
            pnlDisplay.SetActive(true);
            pnlCharacterName.SetActive(true);
            txtDisplay.gameObject.SetActive(true);
            txtCharacterName.gameObject.SetActive(true);            
            DoDialogue();
           
        }
    }
}
