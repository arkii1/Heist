using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Utility/State Action Switch")]
    public class StateActionSwitch : StateAction
    {
        public BoolVariable targetBool;

        public StateAction trueAction;
        public StateAction falseAction;

        public override void Execute(StateManager state)
        {
            if (targetBool.value)
                trueAction.Execute(state);
            else
                falseAction.Execute(state);
        }
    }
}

