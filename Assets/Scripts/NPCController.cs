using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject player;
        
    public Material m;
    
    bool canClick = false;
    

    private void OnMouseDown()
    {        
        if (canClick)
        {
            DialogueManager.Instance.clicked = true;
        }       
    }

    private void OnMouseEnter()
    {
        if (WithinDistance()) m.color = Color.green;
    }

    private void OnMouseExit()
    {
        if (WithinDistance()) m.color = Color.yellow;
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
        if (WithinDistance()) { canClick = true; m.color = Color.green; }
        else { canClick = false; m.color = Color.yellow; }


    }


}
