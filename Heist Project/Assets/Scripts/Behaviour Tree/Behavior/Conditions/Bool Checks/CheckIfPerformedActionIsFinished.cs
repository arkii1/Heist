using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Bool Checks/Check If Performed Action Is Finished")]
    public class CheckIfPerformedActionIsFinished : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            if (!state.isPerformingAction)
                return true;

            return false;
        }
    }
}
