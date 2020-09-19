using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Animation And Hooks Related/Init Anim Hook")]
    public class InitAnimHook : StateAction
    {
        public override void Execute(StateManager state)
        {
            GameObject model = state.anim.gameObject;

            state.animHook = model.AddComponent<AnimatorHook>();
            state.animHook.Init(state);
        }
    }
}
