using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;

public class StateIsPerformingActionBehaviour : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<StateManager>().isPerformingAction = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<StateManager>().isPerformingAction = false;
    }
}
