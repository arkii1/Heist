using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/AI/Check If Player Is Alive")]
    public class CheckIfPlayerIsAlive : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return !GameObject.FindGameObjectWithTag("Player").GetComponent<StateManager>().isDead;
        }
    }
}

