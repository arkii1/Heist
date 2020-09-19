using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;

public class OnEnterIsPerformingActionEqualsValue : StateMachineBehaviour
{
    public bool value;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<StateManager>().isPerformingAction = value;
    }



}
