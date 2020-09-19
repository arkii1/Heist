using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Manager Related/Load Weapon")]
    public class LoadWeapon : StateAction
    {
        public override void Execute(StateManager state)
        {
            ResourceManager rm = GameManager.GetResourcesManager();

            Weapon targetWeapon = (Weapon)rm.GetItem(state.inventory.weaponID);

            state.inventory.curWeapon = targetWeapon.InitNewRuntimeWeapon();
        }
    }

}
