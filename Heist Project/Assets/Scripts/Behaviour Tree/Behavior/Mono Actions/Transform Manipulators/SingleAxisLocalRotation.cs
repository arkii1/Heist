using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Transform Manipulators/Locally Rotate Around Single Axis From Input")]
    public class SingleAxisLocalRotation : Action
    {
        public InputAxis inputAxis;
        public TransformVariable targetTransform;
        public float angle;
        public float speed = 9;
        public Axis targetAxis;

        public bool inverse;

        public bool clamp;
        public float maxClamp = 35;
        public float minClamp = -35;

        private void OnEnable()
        {
            angle = 0;
        }

        public override void Execute()
        {
            if (!inverse)
            {
                angle += inputAxis.value * speed;
            }
            else
            {
                angle -= inputAxis.value * speed;
            }

            if (clamp)
            {
                angle = Mathf.Clamp(angle, minClamp, maxClamp);
            }

            switch (targetAxis)
            {
                case Axis.x:
                    targetTransform.value.localRotation = Quaternion.Euler(angle, targetTransform.value.localEulerAngles.y, targetTransform.value.localEulerAngles.z);
                    break;
                case Axis.y:
                    targetTransform.value.localRotation = Quaternion.Euler(targetTransform.value.localEulerAngles.x, angle, targetTransform.value.localEulerAngles.z);
                    break;
                case Axis.z:
                    targetTransform.value.localRotation = Quaternion.Euler(targetTransform.value.localEulerAngles.x, targetTransform.value.localEulerAngles.y, angle);
                    break;
                default:
                    break;
            }
        }
    }
}

