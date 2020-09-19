using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Action Conditions/Reload")]
    public class ReloadCondition : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            bool retVal = false;

            RuntimeWeapon t_weapon = state.inventory.curWeapon;
            Ammo t_ammo = t_weapon.ammoType;
            AmmoInInventory t_invAmmo = null;

            switch (state.type)
            {
                case StateManagerType.player:
                    if (state.wantsToReload)
                    {
                        for (int i = 0; i < state.inventory.ammos.Count; i++)
                        {
                            if (state.inventory.ammos[i].ammoType == t_ammo)
                            {
                                t_invAmmo = state.inventory.ammos[i];
                                break;
                            }
                        }

                        if (t_invAmmo.amount > 0 && t_weapon.currentBullets < t_weapon.magazineBullets)
                        {
                            retVal = true;
                        }
                    }
                    break;
                case StateManagerType.guard:

                    for (int i = 0; i < state.inventory.ammos.Count; i++)
                    {
                        if (state.inventory.ammos[i].ammoType == t_ammo)
                        {
                            t_invAmmo = state.inventory.ammos[i];
                            break;
                        }
                    }

                    if (t_invAmmo.amount > 0 && t_weapon.currentBullets == 0)
                    {
                        retVal = true;
                    }
                    break;
                default:
                    break;
            }

            
           
            return retVal;
        }
    }
}
