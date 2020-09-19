using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/Action Conditions/Shoot")]
    public class ShootCondition : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            bool retVal = false;

            RuntimeWeapon w = state.inventory.curWeapon;

            switch (state.type)
            {
                case StateManagerType.player:
                    if (state.wantsToShoot)
                    {
                        if (w.currentBullets > 0)
                        {
                            if (Time.realtimeSinceStartup - w.weaponHook.lastFired > w.fireRate)
                            {
                                retVal = true;
                            }
                        }
                    }
                    break;
                case StateManagerType.guard:
                    if(!state.isInteracting && !state.isPerformingAction)
                    {
                        if (w.currentBullets > 0)
                        {
                            if (Time.realtimeSinceStartup - w.weaponHook.lastFired > w.fireRate)
                            {
                                retVal = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return retVal;
        }
    }
}

