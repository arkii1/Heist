using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class OnEnableAssignStateManager : MonoBehaviour
    {
        public StateVariable targetVariable;

        private void OnEnable()
        {
            targetVariable.value = GetComponent<StateManager>();
            Destroy(this);
        }
    }
}

