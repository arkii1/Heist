using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Bool Checks/Check If Wants To Interact")]
    public class CheckIfWantsToInteract : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.wantsToInteract;
        }
    }
}

