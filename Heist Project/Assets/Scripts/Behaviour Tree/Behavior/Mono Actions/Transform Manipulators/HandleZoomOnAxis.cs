using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Transform Manipulators/Handle Zoom On Axis")]
    public class HandleZoomOnAxis : Action
    {
        public TransformVariable targetTransform;
        public BoolVariable targetBool;
        
        public BoolVariable blockerBool;

        public float trueValue;
        public float falseValue;
        public float lerpSpeed;

        public Axis targetAxis;

        float actualValue;

        public override void Execute()
        {
            if (targetTransform == null || targetTransform.value == null)
                return;
            if (targetBool == null)
                return;

            float targetValue = targetBool.value? trueValue : falseValue;
            if (blockerBool != null)
                if (blockerBool.value)
                    targetValue = falseValue;

            actualValue = Mathf.Lerp(actualValue, targetValue, lerpSpeed * Time.deltaTime);

            Vector3 targetPosition = targetTransform.value.localPosition;
            switch (targetAxis)
            {
                case Axis.x:
                    targetPosition.x = actualValue;
                    break;
                case Axis.y:
                    targetPosition.y = actualValue;
                    break;
                case Axis.z:
                    targetPosition.z = actualValue;
                    break;
                default:
                    break;
            }

            targetTransform.value.localPosition = targetPosition;
        }
    }
}
