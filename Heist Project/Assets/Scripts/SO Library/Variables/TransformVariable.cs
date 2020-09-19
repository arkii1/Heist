using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Variables/Transform Variable")]
    public class TransformVariable : ScriptableObject
    {
        public Transform value;

        public void Set(Transform v)
        {
            value = v;
        }

        public void Set(TransformVariable v)
        {
            value = v.value;
        }

        public void Clear()
        {
            value = null;
        }
    }
}
