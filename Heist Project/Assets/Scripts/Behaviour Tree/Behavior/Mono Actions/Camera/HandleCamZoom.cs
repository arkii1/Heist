using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Camera/Handle Camera Zoom")]
    public class HandleCamZoom : Action
    {
        public StateVariable playerState;
        public TransformVariable targetTransform;

        public float aimValue = -1.5f;
        public float runValue = -5;
        public float sprintValue = -1.5f;
        public float crouchValue = -3;
        public float crouchAimValue = -2;

        public float lerpSpeed;

        [SerializeField]
        float actualValue;

        public override void Execute()
        {
            float targetValue;

            if (playerState.value.isSprinting)
            {
                targetValue = sprintValue;
            }
            else if (playerState.value.isAiming && playerState.value.rb.velocity.magnitude < 4 && !playerState.value.isCrouching)
            {
                targetValue = aimValue;
            }
            else if (playerState.value.isCrouching)
            {
                if (playerState.value.isAiming)
                {
                    targetValue = crouchAimValue;
                }
                else
                {
                    targetValue = crouchValue;
                }
            }
            else
            {
                targetValue = runValue;
            }

            actualValue = Mathf.Lerp(actualValue, targetValue, lerpSpeed * Time.deltaTime);

            Vector3 targetPosition = targetTransform.value.localPosition;
            targetPosition.z = actualValue;

            targetTransform.value.localPosition = targetPosition;
        }
    }
}
