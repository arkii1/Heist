using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Navmesh/Set Destination To Key Area")]
    public class SetGuardDestinationToKeyArea : StateAction
    {
        public override void Execute(StateManager state)
        {
            state.agent.SetDestination(GameManager.GetAIManager().GetKeyArea().position);
        }
    }
}

