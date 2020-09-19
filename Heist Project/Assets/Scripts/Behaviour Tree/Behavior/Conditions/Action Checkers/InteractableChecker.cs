using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;
using SO;


namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Interactable Checker")]
    public class InteractableChecker : Condition
    {
        public ColliderVariable objToInteractWith = null;

        public Collider[] results = new Collider[0];

        public float interactRange = 5;

        public override bool CheckCondition(StateManager state)
        {
            Vector3 centre = state.movementValues.aimPosition;
            Vector3 halfExtents = new Vector3(1, 1, 1);
            results = new Collider[0];

            if (Vector3.Distance(state.transform.position, centre) <= interactRange)
            {
                results = Physics.OverlapBox(centre, halfExtents, Quaternion.identity);

                if (results.Length == 0)
                    objToInteractWith.value = null;

                for (int i = 0; i < results.Length; i++)
                {
                    if (results[i].GetComponent<IInteractable>() == null)
                        continue;

                    if (results[i].transform.parent == state.inventory.curWeapon.weaponInstance.gameObject)
                        continue;

                    if (objToInteractWith.value == null)
                    {
                        objToInteractWith.value = results[i];
                        continue;
                    }

                    if (Vector3.Distance(objToInteractWith.value.transform.position, state.transform.position) > Vector3.Distance(results[i].transform.position, state.transform.position))
                    {
                        objToInteractWith.value = results[i];
                    }
                }
            }
            if (objToInteractWith.value != null)
            {
                return true;
            }

            return false;
        }
    }
}
