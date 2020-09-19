using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "Managers/AIManager")]
    public class AIManager : ScriptableObject
    {
        public KeyArea[] keyAreas;

        public List<StateManager> guards = new List<StateManager>();

        public void AddGuard(StateManager st)
        {
            if (guards.Contains(st))
                return;

            guards.Add(st);
        }

        public void RemoveGuard(StateManager st)
        {
            if (!guards.Contains(st))
                return;

            guards.Remove(st);
        }

        int counter = 0;
        public Transform GetKeyArea()
        {
            Transform retVal = null;

            retVal = keyAreas[counter].transform.value;
            keyAreas[counter].guardsAssigned++;
            counter++;

            if (counter > keyAreas.Length - 1)
                counter = 0;

            return retVal;
        }

        private void OnEnable()
        {
            counter = 0;
            guards.Clear();

            foreach (KeyArea key in keyAreas)
            {
                key.guardsAssigned = 0;
            }
        }
    }

    [System.Serializable]
    public class KeyArea
    {
        public int guardsAssigned;

        public TransformVariable transform;
    }
}
