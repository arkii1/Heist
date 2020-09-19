using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Actions/Shoot")]
    public class ShootGun : StateAction
    {
        RuntimeWeapon w;

        public override void Execute(StateManager state)
        {
            state.animHook.StopShootAnim();

            w = state.inventory.curWeapon;

            state.wantsToShoot = false;

            w.weaponHook.lastFired = Time.realtimeSinceStartup;

            w.weaponHook.Shoot();
            state.animHook.PlayShootAnim();

            w.ballistics.Execute(state);

            w.currentBullets--;
        }
    }
}

