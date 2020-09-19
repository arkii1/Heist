using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Transform Manipulators/Rotate Around Single Axis From Input")]
    public class SingleAxisRotation : Action
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
                    targetTransform.value.rotation = Quaternion.Euler(angle, targetTransform.value.eulerAngles.y, targetTransform.value.eulerAngles.z);
                    break;
                case Axis.y:
                    targetTransform.value.rotation = Quaternion.Euler(targetTransform.value.eulerAngles.x, angle, targetTransform.value.eulerAngles.z);
                    break;
                case Axis.z:
                    targetTransform.value.rotation = Quaternion.Euler(targetTransform.value.eulerAngles.x, targetTransform.value.eulerAngles.y, angle);
                    break;
                default:
                    break;
            }
        }
    }
}

