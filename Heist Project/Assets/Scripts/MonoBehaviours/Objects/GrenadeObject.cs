using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class GrenadeObject : MonoBehaviour
    {
        public AudioHolder explosionAudio;

        private void Awake()
        {
            Destroy(gameObject, 3f);
        }

        private void OnDestroy()
        {
            GameObject obj = GameManager.GetObjectPooler().RequestObject("FragExplosion");
            AudioSource source = obj.AddComponent<AudioSource>();
            source.pitch = explosionAudio.GetPitch();
            source.clip = explosionAudio.GetClip();
            source.spatialBlend = 1;
            source.Play();
            obj.transform.position = transform.position;
        }
    }
}

