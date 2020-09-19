using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Setters/Bools/Set Wants To Shoot To Value")]
    public class SetWantsToShootToValue : StateAction
    {
        public bool value;

        public override void Execute(StateManager state)
        {
            state.wantsToShoot = value;
        }
    }

}
