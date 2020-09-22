using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;

public class AlarmTrigger : MonoBehaviour
{
    bool alreadyCalled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyCalled) return;

        if (other.CompareTag("Player"))
        {
            GameManager.GetGameLoopManager().ActivateAlarm();
            alreadyCalled = true;
        }
    }

}
