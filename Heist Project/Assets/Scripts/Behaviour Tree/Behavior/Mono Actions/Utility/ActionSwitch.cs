using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Utility/Action Switch")]
    public class ActionSwitch : Action
    {
        public BoolVariable targetBool;

        public Action trueAction;
        public Action falseAction;

        public override void Execute()
        {
            if (targetBool.value)
                trueAction.Execute();
            else
                falseAction.Execute();
        }
    }
}
