using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Transform Manipulators/Mimic Transform")]
    public class MimicTransform : Action
    {
        public TransformVariable currentTransform;
        public TransformVariable targetTransform;

        public override void Execute()
        {
            currentTransform.value.position = targetTransform.value.position;
            currentTransform.value.rotation = targetTransform.value.rotation;
        }
    }

}
