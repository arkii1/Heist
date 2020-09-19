using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Set Forward Transform To Player")]
    public class SetTransformForwardToPlayer : StateAction
    {
        public override void Execute(StateManager state)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector3 dirToPlayer = new Vector3(player.transform.position.x - state.mTransform.position.x, 0, player.transform.position.z - state.mTransform.position.z).normalized;

            state.mTransform.forward = dirToPlayer;
        }
    }
}

