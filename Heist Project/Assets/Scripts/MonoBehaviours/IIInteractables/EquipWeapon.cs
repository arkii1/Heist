using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class EquipWeapon : MonoBehaviour, IInteractable
    {
        public string targetID;

        [HideInInspector]
        public RuntimeWeapon weapon;

        private void Start()
        {
            if (targetID != null)
            {
                ResourceManager rm = GameManager.GetResourcesManager();
                Weapon targetWeapon = (Weapon)rm.GetItemInstance(targetID);
                weapon = targetWeapon.InitNewRuntimeWeapon();

                weapon.weaponInstance.transform.position = transform.position;
                weapon.weaponInstance.transform.rotation = transform.rotation;

                weapon.weaponInstance.AddComponent<EquipWeapon>();
                weapon.weaponInstance.GetComponent<EquipWeapon>().weapon = weapon;

                weapon.weaponInstance.GetComponent<Collider>().enabled = true;

                Rigidbody rb = weapon.weaponInstance.AddComponent<Rigidbody>();
                rb.mass = 0.1f;
                rb.drag = 0;
                rb.angularDrag = 0;
                rb.interpolation = RigidbodyInterpolation.Extrapolate;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

                Destroy(gameObject);
            }
        }

        public void Interact(StateManager state)
        {
            //Set state weapon to be this ones replacement
            RuntimeWeapon stateWeapon = state.inventory.curWeapon;
            stateWeapon.weaponInstance.transform.parent = this.transform.parent;
            stateWeapon.weaponInstance.GetComponent<Collider>().enabled = true;
            stateWeapon.weaponInstance.AddComponent<EquipWeapon>();
            stateWeapon.weaponInstance.GetComponent<EquipWeapon>().weapon = stateWeapon;
            Rigidbody rb = stateWeapon.weaponInstance.AddComponent<Rigidbody>();
            rb.mass = 0.1f;
            rb.drag = 0;
            rb.angularDrag = 0;
            rb.interpolation = RigidbodyInterpolation.Extrapolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;


            //Add this weapon to the state manager
            Destroy(weapon.weaponInstance.gameObject.GetComponent<Rigidbody>());
            weapon.weaponInstance.GetComponent<Collider>().enabled = false;
            state.inventory.curWeapon = weapon;
            state.animHook.LoadWeapon(weapon);

            Destroy(this);
        }
    }
}
