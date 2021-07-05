using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP.UI
{
    public class UIUpdater : MonoBehaviour
    {
        public StateVariable playerState;

        public List<UIElement> elements = new List<UIElement>();

        public static UIUpdater singleton;

        private void Awake()
        {
            if (singleton == null)
                singleton = this;
            else
                Destroy(this.gameObject);
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Init();
            }
        }

        private void Update()
        {
            float delta = Time.deltaTime;

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Tick(delta);
            }
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].FixedTick(delta);
            }
        }
    }
}
