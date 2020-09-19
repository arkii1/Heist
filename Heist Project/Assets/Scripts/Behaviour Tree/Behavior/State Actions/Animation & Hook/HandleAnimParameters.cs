using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Animation And Hooks Related/Handle Animation Parameters")]
    public class HandleAnimParameters : StateAction
    {
        public override void Execute(StateManager state)
        {
            switch (state.type)
            {
                case StateManagerType.player:
                    state.anim.SetFloat("horizontal", state.movementValues.horizontal, 0.2f, state.delta);
                    state.anim.SetFloat("vertical", state.movementValues.vertical, 0.02f, state.delta);
                    state.anim.SetFloat("moveAmount", state.movementValues.moveAmount, 0.02f, state.delta);
                    break;
                case StateManagerType.guard:
                    state.anim.SetFloat("moveAmount", state.agent.velocity.magnitude / state.agent.speed);
                    //RELATIVE
                    Vector3 localVel = state.mTransform.InverseTransformVector(state.agent.velocity);
                    state.anim.SetFloat("horizontal", localVel.x / state.agent.speed);
                    state.anim.SetFloat("vertical", localVel.z / state.agent.speed);
                    break;
                default:
                    break;
            }

            state.anim.SetBool("isAiming", state.isAiming);
            state.anim.SetBool("isSprinting", state.isSprinting);
            state.anim.SetBool("isCrouching", state.isCrouching);
            state.anim.SetBool("isInteracting", state.isInteracting);

            state.anim.SetInteger("consecutiveShots", state.inventory.curWeapon.weaponHook.consecutiveShots);
        }
    }
}

