using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Variables/State Variable")]
    public class StateVariable : ScriptableObject
    {
        public StateManager value;
    }
}

