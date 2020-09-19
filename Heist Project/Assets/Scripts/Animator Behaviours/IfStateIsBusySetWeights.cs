using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;

public class IfStateIsBusySetWeights : StateMachineBehaviour
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateManager state = animator.GetComponent<StateManager>();

        if(state.isInteracting || state.isPerformingAction)
        {
            animator.SetLayerWeight(3, 0);
        }
        else
        {
            animator.SetLayerWeight(3, 1);
        }
    }


}
