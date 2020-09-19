using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Animation And Hooks Related/Assign Consecutive Shot Counter")]
    public class AssignConsecutiveShots : StateAction
    {
        public Condition canIShoot;

        public override void Execute(StateManager state)
        {
            RuntimeWeapon runtimeWeapon = state.inventory.curWeapon;

            if (runtimeWeapon.isAutomatic)
            {
                switch (state.type)
                {
                    case StateManagerType.player:
                        if (state.wantsToShoot && canIShoot.CheckCondition(state))
                        {
                            if (Time.realtimeSinceStartup - runtimeWeapon.weaponHook.lastFired < runtimeWeapon.fireRate + 0.1f)//0.1f is the buffer time to shoot
                            {
                                runtimeWeapon.weaponHook.consecutiveShots += 1;
                            }
                            else
                            {
                                runtimeWeapon.weaponHook.consecutiveShots = 0;
                            }
                        }
                        else if (Time.realtimeSinceStartup - runtimeWeapon.weaponHook.lastFired >= runtimeWeapon.fireRate + 0.1f)
                        {
                            runtimeWeapon.weaponHook.consecutiveShots = 0;
                        }
                        break;
                    case StateManagerType.guard:
                        if (canIShoot.CheckCondition(state))
                        {
                            if (Time.realtimeSinceStartup - runtimeWeapon.weaponHook.lastFired < runtimeWeapon.fireRate + 0.1f)//0.1f is the buffer time to shoot
                            {
                                runtimeWeapon.weaponHook.consecutiveShots += 1;
                            }
                            else
                            {
                                runtimeWeapon.weaponHook.consecutiveShots = 0;
                            }
                        }
                        else if (Time.realtimeSinceStartup - runtimeWeapon.weaponHook.lastFired >= runtimeWeapon.fireRate + 0.1f)
                        {
                            runtimeWeapon.weaponHook.consecutiveShots = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                runtimeWeapon.weaponHook.consecutiveShots = 0;
            }
        }
    }
}

