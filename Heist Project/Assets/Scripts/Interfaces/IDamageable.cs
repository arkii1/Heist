using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public interface IDamageable
    {
        void TakeDamage(float damage, ContactPoint contactPoint);
    }

}

