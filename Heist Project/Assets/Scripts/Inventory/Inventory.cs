using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [System.Serializable]
    public class Inventory
    {
        public string weaponID;
        public RuntimeWeapon curWeapon;

        public List<AmmoInInventory> ammos = new List<AmmoInInventory>();

        public List<GrenadesInInventory> grenades = new List<GrenadesInInventory>();
        public GrenadesInInventory selectedGrenade;

        public void Init()
        {
            if(grenades.Count > 0)
                selectedGrenade = grenades[0];
        }
    }

    [System.Serializable]
    public class AmmoInInventory
    {
        public Ammo ammoType;
        public int amount;
    }

    [System.Serializable]
    public class GrenadesInInventory
    {
        public Grenade grenadeType;
        public int amount;
    }
}
