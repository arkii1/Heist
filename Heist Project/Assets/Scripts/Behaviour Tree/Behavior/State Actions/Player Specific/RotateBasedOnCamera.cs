using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Player Specific/Rotate Based On Camera")]
    public class RotateBasedOnCamera : StateAction
    {
        public float rotateSpeed = 8;

        public override void Execute(StateManager state)
        {
            Vector3 targetDir = state.movementValues.moveDirection;

            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = state.mTransform.forward;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRot = Quaternion.Slerp(state.mTransform.rotation,
                                                    tr,
                                                    state.delta * rotateSpeed * state.movementValues.moveAmount);
            state.mTransform.rotation = targetRot;
        }
    }
}

