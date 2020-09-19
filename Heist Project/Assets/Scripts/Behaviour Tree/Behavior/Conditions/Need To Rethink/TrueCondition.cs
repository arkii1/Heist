using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/True")]
    public class TrueCondition : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return true;
        }
    }

}
