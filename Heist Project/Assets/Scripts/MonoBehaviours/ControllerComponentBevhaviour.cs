using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class ControllerComponentBevhaviour : MonoBehaviour
    {
        StateManager state;
        CapsuleCollider col;

        public float colliderStandHeight, colliderStandYCentre, colliderCrouchHeight, colliderCrouchYCentre;

        private void Awake()
        {
            state = GetComponent<StateManager>();
            col = GetComponent<CapsuleCollider>();
        }

        private void Update()
        {
            if (state.isCrouching)
            {
                col.center = new Vector3(col.center.x, colliderCrouchYCentre, col.center.z);
                col.height = colliderCrouchHeight;
            }
            else
            {
                col.center = new Vector3(col.center.x, colliderStandYCentre, col.center.z);
                col.height = colliderStandHeight;
            }
        }
    }
}

