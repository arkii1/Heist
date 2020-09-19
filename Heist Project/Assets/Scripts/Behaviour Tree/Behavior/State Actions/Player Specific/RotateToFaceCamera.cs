using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Player Specific/Rotate To Face Camera")]
    public class RotateToFaceCamera : StateAction
    {
        public float rotateSpeed = 8;

        public override void Execute(StateManager state)
        {
            Vector3 targetDir = state.movementValues.lookDirection;
            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = state.mTransform.forward;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRot = Quaternion.Slerp(state.mTransform.rotation,
                                                    tr,
                                                    state.delta * rotateSpeed);
            state.mTransform.rotation = targetRot;
        }
    }
}

