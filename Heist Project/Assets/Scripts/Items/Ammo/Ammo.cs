using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Items/Ammo")]
    public class Ammo : Item
    {
        public GameObject prefabModel;
        public float velocity = 30;
        public float damage;
    }
}

