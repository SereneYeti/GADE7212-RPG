using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterController : MonoBehaviour
{
    public CharacterController character;
    public CharacterAnimController characterAnim;
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        characterAnim.AnimateIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.Instance.clicked)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            character.Move(move * Time.deltaTime * Speed);
            if (move != Vector3.zero)
            {
                transform.forward = move;
                characterAnim.AnimateMove();
            }
            else
            {
                characterAnim.AnimateIdle();
            }
                
        }            
    }
}
