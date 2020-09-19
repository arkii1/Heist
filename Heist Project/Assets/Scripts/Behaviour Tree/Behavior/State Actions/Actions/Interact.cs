using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Actions/Interact")]
    public class Interact : StateAction
    {
        public ColliderVariable objToInteractWith;

        public override void Execute(StateManager state)
        {
            objToInteractWith.value.GetComponent<IInteractable>().Interact(state);
            objToInteractWith.value = null;
        }
    }
}

