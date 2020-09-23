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


        public Transform GetSafeArea(StateManager state)
        {
            Transform retVal = safeAreas[0].transform.value;

            for (int i = 1; i < safeAreas.Length; i++)
            {
                if (Vector3.Distance(safeAreas[i].transform.value.position, state.transform.position) < Vector3.Distance(retVal.position, state.transform.position))
                {
                    retVal = safeAreas[i].transform.value;
                }
            }
            
            //humanoids assigned isn't really important for the npcs so i will leave it for now

            return retVal;
        }


        public void Init()
        {
            keyAreaCounter = 0;

            guards.Clear();
            npcs.Clear();

            foreach (AreaOfInterest key in keyAreas)
            {
                key.humanoidsAssigned = 0;
            }

            foreach (AreaOfInterest safe in safeAreas)
            {
                safe.humanoidsAssigned = 0;
            }
        }
    }

    [System.Serializable]
    public class AreaOfInterest
    {
        public int humanoidsAssigned;

        public TransformVariable transform;
    }
}
