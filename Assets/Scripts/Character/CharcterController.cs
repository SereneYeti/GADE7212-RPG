using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterController : MonoBehaviour
{
    public CharacterController character;
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
            transform.forward = move;
    }
}
