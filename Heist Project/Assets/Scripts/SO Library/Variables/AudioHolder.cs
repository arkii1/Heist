using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Audio/Audio Holder")]
    public class AudioHolder : ScriptableObject
    {
        public AudioClip[] clips;

        public float minPitch = 1;
        public float maxPitch = 1;

        public AudioClip GetClip()
        {
            int r = Random.Range(0, clips.Length);
            return clips[r];
        }

        public float GetPitch()
        {
            return Random.Range(minPitch, maxPitch);
        }
    }
}
