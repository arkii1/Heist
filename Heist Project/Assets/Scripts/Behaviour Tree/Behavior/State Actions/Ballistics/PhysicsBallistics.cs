using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    public class PhysicsBallistics : StateAction
    {
        public float spreadMult = 1;
        public FloatVariable crosshairSpread;
        protected GameObject parentObj;

        public override void Execute(StateManager state)
        {
            
        }
    }
}
