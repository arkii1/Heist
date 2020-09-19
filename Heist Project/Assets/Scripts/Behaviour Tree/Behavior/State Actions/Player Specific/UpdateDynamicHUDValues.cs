using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Player Specific/Update HUD")]
    public class UpdateDynamicHUDValues : StateAction
    {
        public FloatVariable targetSpread;

        public float idleSpread = 25;
        public float runningSpread = 50;
        public float aimingSpread = 10;
        public float aimRunningSpread = 30;
        public float interactingSpread;

        public override void Execute(StateManager state)
        {
            if (state.rb.velocity.sqrMagnitude < 0.05f && state.isAiming)//stationary aiming
            {
                targetSpread.value = aimingSpread;
            }
            else if (state.rb.velocity.sqrMagnitude < 0.05f && !state.isAiming)//idle
            {
                targetSpread.value = idleSpread;
            }
            else if(state.rb.velocity.sqrMagnitude >= 0.05f && state.isAiming) //running aiming
            {
                targetSpread.value = aimRunningSpread;
            }
            else if (state.rb.velocity.sqrMagnitude >= 0.05f && !state.isAiming) //running
            {
                targetSpread.value = runningSpread;
            }
            else if (state.isInteracting)
            {
                targetSpread.value = interactingSpread;
            }
        }
    }

}
