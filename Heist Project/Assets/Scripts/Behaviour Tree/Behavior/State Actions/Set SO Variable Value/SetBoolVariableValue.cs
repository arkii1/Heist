using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Set SO Variable Value/Bool")]
    public class SetBoolVariableValue : StateAction
    {
        public BoolVariable targetBoolVariable;
        public bool targetValue;

        public override void Execute(StateManager state)
        {
            targetBoolVariable.value = targetValue;
        }
    }
}

