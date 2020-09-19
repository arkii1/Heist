using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Setters/Bools/Set Is Performing Action To Value")]
    public class SetIsPerformingActionToValue : StateAction
    {
        public bool value = true;

        public override void Execute(StateManager state)
        {
            state.isPerformingAction = value;
        }
    }
}

