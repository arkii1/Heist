using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Inputs/Input Button")]
    public class InputButton : Action
    {
        public string targetButton;
        public bool isPressed;
        public bool toggle = false;
        public KeyState keyState;
        public bool updateBoolVar = true;
        public BoolVariable targetVariable;

        public override void Execute()
        {
            if (!toggle)
            {
                switch (keyState)
                {
                    case KeyState.onDown:
                        isPressed = Input.GetButtonDown(targetButton);
                        break;
                    case KeyState.onCurrent:
                        isPressed = Input.GetButton(targetButton);
                        break;
                    case KeyState.onUp:
                        isPressed = Input.GetButtonUp(targetButton);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (Input.GetButtonDown(targetButton))
                    isPressed = !isPressed;
            }
            

            if (updateBoolVar)
            {
                if (targetVariable != null)
                {
                    targetVariable.value = isPressed;
                }
            }
        }
    }
}

