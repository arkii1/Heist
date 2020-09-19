using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Variables/GameObject Variable")]
    public class GameObjectVariable : ScriptableObject
    {
        public GameObject value;
    }
}

