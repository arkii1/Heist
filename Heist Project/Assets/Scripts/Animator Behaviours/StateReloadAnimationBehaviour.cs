using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;

public class StateReloadAnimationBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateManager state = animator.GetComponent<StateManager>();

        switch (state.type)
        {
            case StateManagerType.player:
                animator.GetComponent<StateManager>().isPerformingAction = true;
                break;
            case StateManagerType.guard:
                break;
            default:
                break;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
