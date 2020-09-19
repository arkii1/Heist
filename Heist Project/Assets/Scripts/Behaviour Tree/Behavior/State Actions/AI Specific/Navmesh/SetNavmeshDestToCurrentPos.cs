using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Navmesh/Set Destination To Current Position")]
    public class SetNavmeshDestToCurrentPos : StateAction
    {
        public override void Execute(StateManager state)
        {
            state.agent.SetDestination(state.mTransform.position);
        }
    }
}
