using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Navmesh/Set Nav Mesh Destination To Player")]
    public class SetNavDestinationToPlayer : StateAction
    {
        public override void Execute(StateManager state)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;

            state.agent.SetDestination(player.position);
        }
    }
}
