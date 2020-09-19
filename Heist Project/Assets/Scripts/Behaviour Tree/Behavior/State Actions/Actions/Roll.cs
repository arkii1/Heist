using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Actions/Roll")]
    public class Roll : StateAction
    {
        public float rollSpeed = 15;

        Vector3 ogForward;

        bool alreadyPlayedAnim = false;

        public override void Execute(StateManager state)
        {
            if (!state.wantsToRoll)
            {
                alreadyPlayedAnim = false;
                return;
            }

            if (!alreadyPlayedAnim)
            {
                alreadyPlayedAnim = true;
                ogForward = state.mTransform.forward;

                state.animHook.PlayRollAnimation();
            }

            state.rb.velocity = ogForward * rollSpeed;
        }
    }

}
