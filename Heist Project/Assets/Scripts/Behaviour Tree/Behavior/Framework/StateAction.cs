using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public abstract class StateAction : ScriptableObject
    {
        public abstract void Execute(StateManager state);
    }
}
