using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName ="SP/Conditions/AI/Is Guard Within Range Of Player")]
    public class IsGuardWithinRangeOfPlayer : Condition
    {
        Transform player;

        public float rangeToReturnTrue = 10;

        private void OnEnable()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override bool CheckCondition(StateManager state)
        {
            if (Vector3.Distance(state.mTransform.position, player.position) <= rangeToReturnTrue)
                return true;

            return false;
        }
    }
}

