using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class WeaponHook : MonoBehaviour
    {
        public Transform bulletSpawnPoint;
        public Transform leftHandIK;
        [HideInInspector]
        public float lastFired;

        ParticleSystem[] particles;

        AudioSource audioSource1;
        AudioSource audioSource2;

        AudioHolder shootingAudio;
        AudioHolder reloadingAudio;

        public bool isShooting;

        public int consecutiveShots = 0;

        public void Init(AudioHolder _shootingAudio, AudioHolder _reloadingAudio)
        {
            shootingAudio = _shootingAudio;
            reloadingAudio = _reloadingAudio;

            GameObject go = new GameObject();
            go.name = "Audio Holder";
            go.transform.parent = bulletSpawnPoint.transform;
            audioSource1 = go.AddComponent<AudioSource>();
            audioSource1.playOnAwake = false;
            audioSource2 = go.AddComponent<AudioSource>();
            audioSource2.playOnAwake = false;
            audioSource1.spatialBlend = 1;
            audioSource2.spatialBlend = 1;

            particles = GetComponentsInChildren<ParticleSystem>();
        }

        public void Shoot()
        {
            isShooting = true;

            AudioSource source = GetAudioSource();
            source.pitch = shootingAudio.GetPitch();
            source.clip = shootingAudio.GetClip();
            source.Play();

            if (particles != null)
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].Play();
                }
            }
        }

        public void Reload()
        {
            AudioSource source = GetAudioSource();
            source.pitch = reloadingAudio.GetPitch();
            source.clip = reloadingAudio.GetClip();
            source.Play();
        }

        bool useAudioSource1 = true;
        private AudioSource GetAudioSource()
        {
            if (useAudioSource1)
            {
                useAudioSource1 = false;
                return audioSource1;
            }
            else
            {
                useAudioSource1 = true;
                return audioSource2;
            }
        }
    }
}

