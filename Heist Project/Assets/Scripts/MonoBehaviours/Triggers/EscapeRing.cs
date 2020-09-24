using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class EscapeRing : MonoBehaviour
    {
        public int sceneToLoad = 1;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player") && GameManager.GetMoneyManager().currentMonies > 0)
            {
                other.gameObject.SetActive(false);
                GameManager.GetGameLoopManager().PlayerHasEscaped();
                GameManager.LoadScene(sceneToLoad);
            }
        }
    }
}
