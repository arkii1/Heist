using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

public class UpdateBool : StateMachineBehaviour
{
    public BoolVariable[] targetBools;
    public bool entryValue = true;
    public bool resetOnExit = true;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < targetBools.Length; i++)
        {
            targetBools[i].value = entryValue;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (resetOnExit)
            for (int i = 0; i < targetBools.Length; i++)
            {
                targetBools[i].value = !targetBools[i].value;
            }
    }
}
