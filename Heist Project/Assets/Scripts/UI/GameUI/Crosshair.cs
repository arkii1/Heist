using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;
using System;

namespace SP.UI
{
    public class Crosshair : UIElement
    {
        public StateVariable playerState;
        public FloatVariable actualSpread;

        public Parts[] parts;

        public float spreadSpeed = 5;
        public float maxSpread = 80;
        public float aimSpread = 5;
        public float runSpread = 20;
        public float sprintSpread = 60;
        public float crouchSpread = 0;
        public float crouchAimSpread = -15;
        public float consecutiveShotsMult = 10f;

        float t;
        float curSpread;

        float targetSpread;

        public override void Init()
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].rectTransform.gameObject.SetActive(true);
            }
        }

        public override void Tick(float delta)
        {
            if (playerState.value.isDead)
                return;

            AssignTargetSpread();

            t = delta * spreadSpeed;
            curSpread = Mathf.Lerp(curSpread, targetSpread, t);
            for (int i = 0; i < parts.Length; i++)
            {
                Parts p = parts[i];
                p.rectTransform.anchoredPosition = p.pos * curSpread;
            }

            actualSpread.value = curSpread;
        }

        private void AssignTargetSpread()
        {
            if (playerState.value.isCrouching)
            {
                if (playerState.value.isAiming)
                    targetSpread = crouchAimSpread;
                else
                    targetSpread = crouchSpread;
            }
            else if (playerState.value.isAiming)
                targetSpread = aimSpread;
            else if (playerState.value.isSprinting)
                targetSpread = sprintSpread;
            else
                targetSpread = runSpread;

            if (playerState.value.wantsToShoot)
            {
                targetSpread += playerState.value.inventory.curWeapon.weaponHook.consecutiveShots * consecutiveShotsMult;
            }

            if (targetSpread > maxSpread)
                targetSpread = maxSpread;
        }

        [System.Serializable]
        public class Parts
        {
            public RectTransform rectTransform;
            public Vector2 pos;
        }
    }
}

   

