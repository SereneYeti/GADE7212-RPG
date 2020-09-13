using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameController : MonoBehaviour
{
    public DataManager dataManager;
    
    // Start is called before the first frame update
    void Start()
    {
       
        //dataManager.Save();
        //Load Sage2000 json
        dataManager.file = FileNames.sage2000 + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.s.ToString());
        //Load FinThePhone json
        dataManager.file = FileNames.finThePhone + DialogueManager.Instance.fileExtention;
        dataManager.Load(CharacterIDs.f.ToString());

        Debug.Log("FOUND" + DialogueManager.Instance.Sage2000List.FindLine(DialogueManager.Instance.Sage2000List,-1));
        for(int i = 0; i < DialogueManager.Instance.Sage2000List.Length; i ++)
        {
            Debug.Log(DialogueManager.Instance.Sage2000List.Retrive(i));
            Debug.Log(DialogueManager.Instance.FinThePhoneList.Retrive(i));
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
