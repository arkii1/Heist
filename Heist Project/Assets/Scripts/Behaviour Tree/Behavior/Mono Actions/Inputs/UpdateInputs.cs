using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Actions/Update Actions")]
    public class UpdateInputs : Action
    {
        public Action[] inputs;

        public override void Execute()
        {
            foreach (Action inp in inputs)
            {
                if (inp != null)
                    inp.Execute();
            }
        }
    }
}

