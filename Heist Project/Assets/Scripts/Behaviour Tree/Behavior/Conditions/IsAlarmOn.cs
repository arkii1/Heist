using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/AI/Is Alarm On")]
    public class IsAlarmOn : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            if (GameManager.GetGameLoopManager().phase == GameLoopPhase.alarmedPhase)
                return true;

            return false;
        }
    }
}

