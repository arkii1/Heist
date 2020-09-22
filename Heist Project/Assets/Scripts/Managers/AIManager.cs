using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SP
{
    [CreateAssetMenu(menuName = "Managers/AIManager")]
    public class AIManager : ScriptableObject
    {
        public AreaOfInterest[] keyAreas;
        public AreaOfInterest[] safeAreas;

        public List<StateManager> guards = new List<StateManager>();
        public List<StateManager> npcs = new List<StateManager>();

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

        int keyAreaCounter = 0;
        public Transform GetKeyArea()
        {
            Transform retVal = null;

            retVal = keyAreas[keyAreaCounter].transform.value;
            keyAreas[keyAreaCounter].humanoidsAssigned++;
            keyAreaCounter++;

            if (keyAreaCounter > keyAreas.Length - 1)
                keyAreaCounter = 0;

            return retVal;
        }

        public void AddNPC(StateManager st)
        {
            if (npcs.Contains(st))
                return;

            npcs.Add(st);
        }

        public void RemoveNPC(StateManager st)
        {
            if (!npcs.Contains(st))
                return;

            npcs.Remove(st);
        }


        int safeAreaCounter = 0;
        public Transform SafeKeyArea()
        {
            Transform retVal = null;

            retVal = safeAreas[safeAreaCounter].transform.value;
            safeAreas[safeAreaCounter].humanoidsAssigned++;
            safeAreaCounter++;

            if (safeAreaCounter > safeAreas.Length - 1)
                safeAreaCounter = 0;

            return retVal;
        }


        public void Init()
        {
            keyAreaCounter = 0;
            safeAreaCounter = 0;

            guards.Clear();
            npcs.Clear();

            foreach (AreaOfInterest key in keyAreas)
            {
                key.humanoidsAssigned = 0;
            }

            //foreach (AreaOfInterest safe in safeAreas)
            //{
            //    safe.humanoidsAssigned = 0;
            //}
        }
    }

    [System.Serializable]
    public class AreaOfInterest
    {
        public int humanoidsAssigned;

        public TransformVariable transform;
    }
}
