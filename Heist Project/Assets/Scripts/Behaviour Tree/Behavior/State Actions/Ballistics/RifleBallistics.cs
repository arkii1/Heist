using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Ballistics/Rifle")]
    public class RifleBallistics : PhysicsBallistics
    {
        public override void Execute(StateManager state)
        {
            Transform barrel = state.inventory.curWeapon.weaponHook.bulletSpawnPoint;
            Vector3 original = barrel.position;
            Vector3 dir = (state.movementValues.aimPosition - original).normalized;

            GameObject bullet = Instantiate(state.inventory.curWeapon.ammoType.prefabModel, original, Quaternion.identity);
            bullet.transform.up = dir;

            Vector2 r = Random.insideUnitCircle;
            r *= crosshairSpread.value * spreadMult;
            Vector3 localEulers = bullet.transform.localEulerAngles;
            localEulers.x += r.x;
            localEulers.y += r.y;
            bullet.transform.localEulerAngles = localEulers;

            Vector3 vel = bullet.transform.up * state.inventory.curWeapon.ammoType.velocity;

            float dmg = state.inventory.curWeapon.ammoType.damage;

            if (parentObj == null)
            {
                parentObj = new GameObject();
                parentObj.transform.parent = GameObject.FindGameObjectWithTag("Environment Holder").transform;
                parentObj.name = "Ammo Object Parent";
            }
            bullet.GetComponent<BulletObject>().Init(vel, dmg, parentObj.transform);
        }
    }
}
