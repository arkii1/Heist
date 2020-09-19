using UnityEngine;
using System.Collections;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Bool Checks/Check If Dead")]
    public class CheckIfDead : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            if (state.currentHealth <= 0)
                return true;

            return false;
        }
    }
}
