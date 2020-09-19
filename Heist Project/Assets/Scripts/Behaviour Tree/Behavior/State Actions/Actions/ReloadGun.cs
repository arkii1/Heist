using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Actions/Reload")]
    public class ReloadGun : StateAction
    {
        public override void Execute(StateManager state)
        {
            RuntimeWeapon t_weapon = state.inventory.curWeapon;

            Ammo t_ammo = t_weapon.ammoType;
            AmmoInInventory t_invAmmo = null;

            for (int i = 0; i < state.inventory.ammos.Count; i++)
            {
                if (state.inventory.ammos[i].ammoType == t_ammo)
                {
                    t_invAmmo = state.inventory.ammos[i];
                    break;
                }
            }

            int amount_To_Reload = t_invAmmo.amount >= t_weapon.magazineBullets - t_weapon.currentBullets ? t_weapon.magazineBullets - t_weapon.currentBullets : t_invAmmo.amount;

            state.animHook.PlayReloadAnim();
            state.inventory.curWeapon.weaponHook.Reload();

            t_invAmmo.amount -= amount_To_Reload;
            t_weapon.currentBullets += amount_To_Reload;

            if (t_weapon.currentBullets > t_weapon.magazineBullets)
                Debug.Log(t_weapon.weaponInstance.name + " has more bullets than is allowed in its' magazine!");

        }
    }
}

