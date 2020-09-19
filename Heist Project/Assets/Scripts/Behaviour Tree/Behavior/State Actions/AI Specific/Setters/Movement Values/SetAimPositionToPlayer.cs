using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Setters/Movement Values/Set Aim Pos To Player")]
    public class SetAimPositionToPlayer : StateAction
    {
        public override void Execute(StateManager state)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");


            state.movementValues.aimPosition = player.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Chest).transform.position;
        }
    }
}

