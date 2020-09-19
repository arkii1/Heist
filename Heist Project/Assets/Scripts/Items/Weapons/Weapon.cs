using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Items/Weapon")]
    public class Weapon : Item
    {
        public int magazineBullets = 30;
        public float fireRate = 0.2f;

        public bool isAutomatic = true;

        public Ammo ammoType;

        public Vector3Variable rhAimingPosition;
        public Vector3Variable rhAimingRotation;
        public Vector3Variable rhHipfirePosition;
        public Vector3Variable rhHipfireRotation;

        public Vector3Variable weaponModelPosOffset;
        public Vector3Variable weaponModelRotOffset;

        public AudioHolder shootingAudio;
        public AudioHolder reloadingAudio;

        public GameObject model;

        public PhysicsBallistics ballistics;

        public RuntimeWeapon InitNewRuntimeWeapon()
        {
            RuntimeWeapon runtime = new RuntimeWeapon();
            runtime.weaponInstance = Instantiate(model) as GameObject;
            runtime.weaponHook = runtime.weaponInstance.GetComponent<WeaponHook>();
            runtime.weaponHook.Init(shootingAudio, reloadingAudio);
            runtime.weaponInstance.GetComponentInChildren<Collider>().enabled = false;

            runtime.currentBullets = magazineBullets;
            runtime.magazineBullets = magazineBullets;
            runtime.fireRate = fireRate;

            runtime.isAutomatic = isAutomatic;

            runtime.ammoType = ammoType;

            runtime.rhAimingPos = rhAimingPosition.value;
            runtime.rhAimingRot = rhAimingRotation.value;
            runtime.rhHipfirePos = rhHipfirePosition.value;
            runtime.rhHipfireRot = rhHipfireRotation.value;

            runtime.weaponModelPosOffset = weaponModelPosOffset.value;
            runtime.weaponModelRotOffset = weaponModelRotOffset.value;

            runtime.ballistics = ballistics;

            return runtime;
        }
    }

    [System.Serializable]
    public class RuntimeWeapon
    {
        public GameObject weaponInstance;

        [HideInInspector]
        public bool isAutomatic;
        
        public int currentBullets;
        [HideInInspector]
        public int magazineBullets;
        public float fireRate;

        [HideInInspector]
        public Ammo ammoType;
        [HideInInspector]
        public Vector3 rhAimingPos;
        [HideInInspector]
        public Vector3 rhAimingRot;
        [HideInInspector]
        public Vector3 rhHipfirePos;
        [HideInInspector]
        public Vector3 rhHipfireRot;

        [HideInInspector]
        public Vector3 weaponModelPosOffset;
        [HideInInspector]
        public Vector3 weaponModelRotOffset;

        [HideInInspector]
        public PhysicsBallistics ballistics;

        public WeaponHook weaponHook;
    }
}

