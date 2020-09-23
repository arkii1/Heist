using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Navmesh/Is State Close Enough To Dest")]
    public class IsStateCloseEnoughToDestination : StateAction
    {
        public override void Execute(StateManager state)
        {
            if (Vector3.Distance(state.transform.position, state.agent.destination) < 2)
                state.agent.SetDestination(state.transform.position);
        }
    }
}

