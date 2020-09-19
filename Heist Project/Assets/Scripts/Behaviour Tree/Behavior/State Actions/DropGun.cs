using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Unsure/Drop Gun")]
    public class DropGun : StateAction
    {
        public override void Execute(StateManager state)
        {
            RuntimeWeapon stateWeapon = state.inventory.curWeapon;
            stateWeapon.weaponInstance.transform.parent = GameObject.Find("Environment/Items").transform;
            stateWeapon.weaponInstance.GetComponent<Collider>().enabled = true;
            stateWeapon.weaponInstance.AddComponent<EquipWeapon>();
            stateWeapon.weaponInstance.GetComponent<EquipWeapon>().weapon = stateWeapon;
            Rigidbody rb = stateWeapon.weaponInstance.AddComponent<Rigidbody>();
            rb.mass = 0.1f;
            rb.drag = 0;
            rb.angularDrag = 0;
            rb.interpolation = RigidbodyInterpolation.Extrapolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            state.inventory.curWeapon = null;
        }
    }
}

