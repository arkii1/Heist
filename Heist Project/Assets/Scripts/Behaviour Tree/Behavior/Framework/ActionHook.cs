﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class ActionHook : MonoBehaviour
    {
        public Action[] updateActions;
        public Action[] fixedUpdateActions;

        void Update()
        {
            if (updateActions.Length == 0)
                return;

            for (int i = 0; i < updateActions.Length; i++)
            {
                updateActions[i].Execute();
            }
        }

        void FixedUpdate()
        {
            if (fixedUpdateActions.Length == 0)
                return;

            for (int i = 0; i < fixedUpdateActions.Length; i++)
            {
                fixedUpdateActions[i].Execute();
            }
        }

    }
}

