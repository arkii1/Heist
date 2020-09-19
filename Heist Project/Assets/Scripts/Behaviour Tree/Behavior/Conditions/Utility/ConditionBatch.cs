using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Utility/Condition Batch")]
    public class ConditionBatch : Condition
    {
        public Condition[] conditions;

        public override bool CheckCondition(StateManager state)
        {
            bool retVal = true;

            for (int i = 0; i < conditions.Length; i++)
            {
                if(!conditions[i].CheckCondition(state))
                {
                    retVal = false;
                    break;
                }
            }

            return retVal;
        }
    }
}

