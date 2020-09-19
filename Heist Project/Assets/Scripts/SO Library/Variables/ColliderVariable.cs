using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Variables/Collider Variable")]
    public class ColliderVariable : ScriptableObject
    {
        public Collider value;
    }
}

