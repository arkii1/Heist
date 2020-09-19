using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Setters/Bools/Set Wants To Reload To Value")]
    public class SetWantsToReloadToValue : StateAction
    {
        public bool value;

        public override void Execute(StateManager state)
        {
            state.wantsToReload = false;
        }
    }
}
