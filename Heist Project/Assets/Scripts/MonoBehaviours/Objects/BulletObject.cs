using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SP
{
    public class BulletObject : MonoBehaviour
    {
        float baseDamage = 0;

        public void Init(Vector3 vel, float dmg, Transform parent)
        {
            transform.parent = parent;
            GetComponent<Rigidbody>().velocity = vel;
            baseDamage = dmg;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Bullet")) return;

            if (collision.gameObject.GetComponent<IDamageable>() != null) //humanoid/breakables
            {
                collision.gameObject.GetComponent<IDamageable>().TakeDamage(baseDamage, collision.GetContact(0));
            }
            else //surface
            {
                GameObject hitParticle = GameManager.GetObjectPooler().RequestObject("BulletImpactSurface");
                hitParticle.transform.position = collision.GetContact(0).point;
                hitParticle.transform.forward = collision.GetContact(0).normal;
            }

            Destroy(this.gameObject);
        }
    }
}

