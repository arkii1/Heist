using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Navmesh/Set AI Destination To Area")]
    public class SetAIDestinationToArea : StateAction
    {
        public override void Execute(StateManager state)
        {
            switch (state.type)
            {
                case StateManagerType.player:
                    break;
                case StateManagerType.guard:
                    state.agent.SetDestination(GameManager.GetAIManager().GetKeyArea().position);
                    break;
                case StateManagerType.npc:
                    state.agent.SetDestination(GameManager.GetAIManager().GetSafeArea(state).position);
                    break;
                default:
                    break;
            }
        }
    }
}

