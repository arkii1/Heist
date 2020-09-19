using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Utility/Init State Action Batch")]
    public class InitStateActionsBatch : StateAction
    {
        public StateAction[] actions;

        public override void Execute(StateManager state)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Execute(state);
            }
        }
    }
}

