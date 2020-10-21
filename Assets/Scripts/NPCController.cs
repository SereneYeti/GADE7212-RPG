using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject player;
        
    public Material m;
    public Material m2;

    bool canClick = false;

    public DialogueController dialogue;
    private void Start()
    {
        //EventManager.Instance.AddListener(EVENT_TYPE.NPC_Click, SendClickNotifacation);
    }
    public void SendClickNotifacation()
    {
        if (canClick)
        {
            DialogueManager.Instance.clicked = true;
            dialogue.interactingID = this.tag;
        }
        if (this.tag == CharacterIDs.s.ToString()) { DialogueManager.Instance.currentInteraction = CharacterIDs.s.ToString(); }
        else if (this.tag == CharacterIDs.b.ToString()) { DialogueManager.Instance.currentInteraction = CharacterIDs.b.ToString(); dialogue.countFin = 9; }
        EventManager.Instance.PostNotification(EVENT_TYPE.NPC_Click, this);
    }
    private void OnMouseDown()
    {   
        SendClickNotifacation();
    }

    private void OnMouseEnter()
    {
        if (this.tag == CharacterIDs.s.ToString()) { if (WithinDistance()) m.color = Color.green; }
        else if (this.tag == CharacterIDs.b.ToString()) { if (WithinDistance()) m2.color = Color.red; }
        
    }

    private void OnMouseExit()
    {
        if (this.tag == CharacterIDs.s.ToString()) { if (WithinDistance()) m.color = Color.yellow; }
        else if (this.tag == CharacterIDs.b.ToString()) { if (WithinDistance()) m2.color = Color.black; }
        
    }

    public bool WithinDistance()
    {
        bool inDist = false;
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 4f)
        { inDist = true; }
        else { inDist = false; }

        return inDist;
    }
    private void Update()
    {
        if (this.tag == CharacterIDs.s.ToString()) { if (WithinDistance()) { canClick = true; m.color = Color.green; } else { canClick = false; m.color = Color.yellow; } }
        else if (this.tag == CharacterIDs.b.ToString()) { if (WithinDistance()) { canClick = true; m2.color = Color.red; } else { canClick = false; m2.color = Color.black; } }
        


    }


}
