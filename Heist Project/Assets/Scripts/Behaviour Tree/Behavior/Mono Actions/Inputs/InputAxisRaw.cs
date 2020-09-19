using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Inputs/Input Axis Raw")]
    public class InputAxisRaw : Action
    {
        public string targetString;
        public float value;

        public override void Execute()
        {
            value = Input.GetAxisRaw(targetString);
        }
    }
}
