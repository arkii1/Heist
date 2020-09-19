using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Add Guard To AI Manager")]
    public class AddGuardToAIManager : StateAction
    {
        public override void Execute(StateManager state)
        {
            GameManager.GetAIManager().AddGuard(state);
        }
    }
}
