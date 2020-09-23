using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class GuardSpawnManager : MonoBehaviour
    {
        public GameObject guardPrefab;

        public int noOfGuardsToSpawn = 10;

        public Transform spawnPoint;

        bool alreadyCalled = false;

        private void Update()
        {
            if (GameManager.GetGameLoopManager().phase == GameLoopPhase.preAlarmPhase || alreadyCalled)
                return;
            alreadyCalled = true;

            Invoke("SpawnGuards", 30);
        }

        private void SpawnGuards()
        {
            for (int i = 0; i < noOfGuardsToSpawn; i++)
            {
                Instantiate(guardPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
            }

            Destroy(this);
        }
    }
}
