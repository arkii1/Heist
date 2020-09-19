using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SP.UI
{
    public class UIElement : MonoBehaviour
    {
        protected UIUpdater updater;

        private void Awake()
        {
            updater = UIUpdater.singleton;

            if (updater != null)
                updater.elements.Add(this);
        }

        public virtual void Init()
        {
        }

        public virtual void Tick(float delta)
        {

        }

        public virtual void FixedTick(float delta)
        {

        }
    }
}

