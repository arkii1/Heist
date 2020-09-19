using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using UnityEngine.UI;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Mono Actions/Inputs/Input Manager")]
    public class InputManager : Action
    {
        #region Variables

        #region  Assigned In Editor 

        public InputAxis horizontal;
        public InputAxis vertical;

        public BoolVariable isAiming;
        public BoolVariable wantsToShoot;
        public BoolVariable wantsToReload;
        public BoolVariable wantsToRoll;
        public BoolVariable wantsToThrowGrenade;
        public BoolVariable isSprinting;
        public BoolVariable isCrouching;
        public BoolVariable wantsToInteract;
        
        public BoolVariable isInteracting; //interacting with something external to the character
        public BoolVariable isPerformingAction; //e.g. roll, shoot, throwing grenade

        public BoolVariable sheatheWeapon;

        public TransformVariable mainCameraTransform;
        public TransformVariable cameraPivotTransform;

        public StateVariable playerStates;

        #endregion

        #region Calculated In Script

        public float moveAmount;
        public Vector3 moveDirection;

        #endregion

        public bool debugAim;

        #endregion

        #region Methods

        private void Awake()
        {
            isAiming.value = false;
            wantsToShoot.value = false;
            wantsToReload.value = false;
            isInteracting.value = false;
        }

        public override void Execute()
        {
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal.value) + Mathf.Abs(vertical.value));

            if(mainCameraTransform != null && mainCameraTransform.value != null)
            {
                moveDirection = mainCameraTransform.value.forward * vertical.value;
                moveDirection += mainCameraTransform.value.right * horizontal.value;
            }

            if(playerStates != null && playerStates.value != null)
            {
                // Set movement values
                playerStates.value.movementValues.horizontal = horizontal.value;
                playerStates.value.movementValues.vertical = vertical.value;
                playerStates.value.movementValues.moveAmount = moveAmount;
                playerStates.value.movementValues.moveDirection = moveDirection;

                 playerStates.value.isInteracting = isInteracting.value;

                if (!playerStates.value.isInteracting)
                    playerStates.value.isPerformingAction = isPerformingAction.value;

                if (playerStates.value.isInteracting || playerStates.value.isPerformingAction)
                {
                    playerStates.value.sheatheWeapon = sheatheWeapon.value;

                    if (playerStates.value.wantsToShoot)
                         playerStates.value.isAiming = isAiming.value;
                    else
                        playerStates.value.isAiming = false;

                    playerStates.value.wantsToShoot = false;
                    playerStates.value.wantsToReload = false;
                    playerStates.value.wantsToThrowGrenade = false;
                    playerStates.value.wantsToRoll = false;
                    playerStates.value.wantsToInteract = false;
                }
                else
                {
                    if (playerStates.value.isSprinting)
                    {
                        playerStates.value.isSprinting = isSprinting.value;
                        playerStates.value.isCrouching = false;

                        playerStates.value.isAiming = false;
                        playerStates.value.wantsToShoot = false;
                        playerStates.value.wantsToReload = false;
                        playerStates.value.wantsToThrowGrenade = false;
                        playerStates.value.isCrouching = false;
                        playerStates.value.wantsToRoll = false;
                        playerStates.value.wantsToInteract = false;

                    }
                    else
                    {
                        playerStates.value.isSprinting = false;
                        playerStates.value.isCrouching = isCrouching.value;

                        playerStates.value.isAiming = isAiming.value;
                        playerStates.value.wantsToShoot = wantsToShoot.value;
                        playerStates.value.wantsToReload = wantsToReload.value;
                        playerStates.value.isSprinting = isSprinting.value;
                        playerStates.value.wantsToThrowGrenade = wantsToThrowGrenade.value;
                        playerStates.value.isCrouching = isCrouching.value;
                        playerStates.value.wantsToRoll = wantsToRoll.value;
                        playerStates.value.wantsToInteract = wantsToInteract.value;
                    }
                    playerStates.value.sheatheWeapon = false;
                }

                if (debugAim)
                    playerStates.value.isAiming = true;

                playerStates.value.movementValues.lookDirection = mainCameraTransform.value.forward;
                Ray ray = new Ray(mainCameraTransform.value.position, mainCameraTransform.value.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    playerStates.value.movementValues.aimPosition = hit.point;
                }
                else
                {
                    playerStates.value.movementValues.aimPosition = ray.GetPoint(100);
                }
            }
        }

        #endregion
    }
}
