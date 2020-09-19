using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Transform Manipulators/Follow Transform")]
    public class FollowTransform : Action
    {
        public TransformVariable currentTransform;
        public TransformVariable targetTransform;
        public Vector3Variable offsetPosition;

        public float followSpeed = 9;

        public override void Execute()
        {
            if (currentTransform.value == null || targetTransform.value == null)
                return;

            Vector3 targetValue = targetTransform.value.position;
            if (offsetPosition != null && offsetPosition.value != null)
                targetValue += offsetPosition.value;

            Vector3 targetPosition = Vector3.Lerp(currentTransform.value.position,
                                                 targetValue,
                                                 followSpeed * Time.deltaTime);
            currentTransform.value.position = targetPosition;
        }
    }
}
