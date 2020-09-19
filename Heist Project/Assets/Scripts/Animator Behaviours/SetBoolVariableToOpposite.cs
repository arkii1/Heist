using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

public class SetBoolVariableToOpposite : StateMachineBehaviour
{
    //ACTUALLY SET TO FALSE
    
    public BoolVariable[] bools;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < bools.Length; i++)
        {
            bools[i].value = false;
        }
    }

}
