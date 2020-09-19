using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Animation And Hooks Related/Die")]
    public class Die : StateAction
    {
        public override void Execute(StateManager state)
        {
            state.animHook.PlayDieAnim();
            state.isDead = true;

            state.mTransform.GetComponent<Collider>().enabled = false;

            state.anim.SetBool("isDead", true);
        }
    }

}
