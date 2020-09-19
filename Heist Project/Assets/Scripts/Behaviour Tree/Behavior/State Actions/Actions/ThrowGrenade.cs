using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Actions/Throw Grenade")]
    public class ThrowGrenade : StateAction
    {
        GameObject spawnedGrenade = null;

        StateManager st;

        public override void Execute(StateManager state)
        {
            if (!state.wantsToThrowGrenade || state.isInteracting || state.isSprinting) return;

            if (state.inventory.selectedGrenade.amount <= 0) return;

            state.inventory.selectedGrenade.amount--;
            st = state;
            state.animHook.PlayThrowGrenadeAnim();
        }

        public void SpawnGrenade()
        {
            spawnedGrenade = Instantiate(st.inventory.selectedGrenade.grenadeType.model, st.anim.GetBoneTransform(HumanBodyBones.RightHand));
            spawnedGrenade.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            spawnedGrenade.GetComponentInChildren<Collider>().enabled = false;
        }

        public void ReleaseGrenade()
        {
            spawnedGrenade.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            spawnedGrenade.GetComponentInChildren<Collider>().enabled = true;
            spawnedGrenade.transform.parent = null;
            spawnedGrenade.transform.forward = (st.movementValues.aimPosition + Vector3.up * 15) - spawnedGrenade.transform.position;
            spawnedGrenade.GetComponent<Rigidbody>().AddForce(spawnedGrenade.transform.forward * 12, ForceMode.Impulse);
        }
    }
}
