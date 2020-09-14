using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public DataManager dataManager;

    Image pnlDisplayMaterial;
    public GameObject pnlDisplay;
    public GameObject pnlCharacterName;
    public TextMeshProUGUI txtDisplay;
    public TextMeshProUGUI txtCharacterName;

    //int countSage;
    //int countFin;
    //int speaker;
    public bool ReadLine = false;
    private void Start()
    {
        //countSage = 0;
        //countFin = 0;
        //speaker = -1;
        //Load Sage2000 json
        dataManager.file = FileNames.sage2000 + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.s.ToString());
        //Load FinThePhone json
        dataManager.file = FileNames.finThePhone + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.f.ToString());
        dataManager.file = FileNames.socialBot + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.b.ToString());


    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DoDialogue()
    {
        #region FromTestProgram
        //dialogueData tempData = new dialogueData();
        //bool finished = false;
        //pnlDisplayMaterial = pnlDisplay.GetComponent<Image>();
        ////The speaker variable will be used to determine & switch the speaker. 0 = SAGE & 1 = FIN        
        //if (speaker == -1)
        //{
        //    speaker = 0;
        //    if (countSage == DialogueManager.Instance.Sage2000List.Length) { Debug.Log("this2"); finished = true; speaker = -2; }
        //}
        //else if (speaker == 0 && !finished)
        //{
        //    pnlDisplayMaterial.color = Color.yellow;
        //    tempData = DialogueManager.Instance.Sage2000List.Retrive(countSage);
        //    SetText(tempData.characterNickname, tempData.characterLine);
        //    NextLine();
        //    if (ReadLine) { speaker = 1; ReadLine = false; countSage++; }
        //}
        //else if (speaker == 1 && !finished)
        //{
        //    pnlDisplayMaterial.color = Color.green;
        //    tempData = DialogueManager.Instance.FinThePhoneList.Retrive(countFin);
        //    SetText(tempData.characterNickname, tempData.characterLine);
        //    NextLine();
        //    if (ReadLine) { speaker = -1; ReadLine = false; countFin++; }
        //}
        //if (speaker == -2 && finished == true)
        //{
        //    countFin = 0;
        //    countSage = 0;
        //    speaker = 0;
        //    Debug.Log("here");
        //    pnlDisplay.SetActive(false);
        //    pnlCharacterName.SetActive(false);
        //    txtDisplay.gameObject.SetActive(false);
        //    txtCharacterName.gameObject.SetActive(false);
        //    DialogueManager.Instance.clicked = false;
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
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            //if (speaker == 0) speaker = 1; else speaker = 0;
            ReadLine = true;
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
