using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using UnityEngine.Events;

namespace SP
{
    public class AnimEventListener : MonoBehaviour
    {
        public UnityEvent myEvent1 = new UnityEvent();
        public UnityEvent myEvent2 = new UnityEvent();

        public void CallEvent1()
        {
            myEvent1.Invoke();
        }

        public void CallEvent2()
        {
            myEvent2.Invoke();
        }
    }
}
