using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SP.UI
{
    public class AmmoText : UIElement
    {
        StateVariable playerState;
        TextMeshProUGUI text;

        int carryingAmmo = -1;

        RuntimeWeapon curWeapon;

        public override void Init()
        {
            playerState = UIUpdater.singleton.playerState;
            text = GetComponent<TextMeshProUGUI>();
            curWeapon = playerState.value.inventory.curWeapon;
        }

        bool getNewCarryingAmmo = false;
        public override void Tick(float delta)
        {
            if (playerState.value.isDead)
                return;

            if (getNewCarryingAmmo)
                carryingAmmo = GetCarryingAmmo();

            if (playerState.value.wantsToReload || carryingAmmo == -1 || playerState.value.animHook.curWeapon != curWeapon)
            {
                if(playerState.value.animHook.curWeapon != curWeapon)
                    curWeapon = playerState.value.animHook.curWeapon;

                getNewCarryingAmmo = true;
            }

            text.text = playerState.value.inventory.curWeapon.currentBullets.ToString() + "/" + carryingAmmo.ToString();

        }

        int GetCarryingAmmo()
        {
            RuntimeWeapon t_weapon = playerState.value.inventory.curWeapon;
            Ammo t_ammo = t_weapon.ammoType;
            AmmoInInventory t_invAmmo = null;

            for (int i = 0; i < playerState.value.inventory.ammos.Count; i++)
            {
                if (playerState.value.inventory.ammos[i].ammoType == t_ammo)
                {
                    t_invAmmo = playerState.value.inventory.ammos[i];
                    break;
                }
            }

            getNewCarryingAmmo = false;

            return t_invAmmo.amount;
        }
    }
}

