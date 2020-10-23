using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    #region Attributes

    private Animator animator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string MOVE_ANIMATION_BOOL = "move";

    #endregion

    #region Animate Functions

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }
    public void AnimateMove()
    {
        Animate(MOVE_ANIMATION_BOOL);
    }

    #endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);

        try { animator.SetBool(boolName, true); }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }       
    }

    private void DisableOtherAnimations(Animator animator, string animation)
    {
        try
        {
            foreach (AnimatorControllerParameter parameter in animator.parameters)
            {
                if (parameter.name != animation)
                {
                    animator.SetBool(parameter.name, false);
                }
            }

        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
