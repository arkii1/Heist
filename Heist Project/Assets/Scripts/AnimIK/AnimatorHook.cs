using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using System;

namespace SP
{
    public class AnimatorHook : MonoBehaviour
    {
        StateManager state;
        Animator anim;

        float bodyWeight;
        float lookWeight;
        float mainHandWeight;
        float offHandWeight;

        Transform rightHandTarget;
        public Transform leftHandTarget;
        public Transform shoulder;
        public Transform aimPivot;
        Vector3 lookDir;

        public Vector3 rhHipPos;
        public Vector3 rhHipRot;
        public Vector3 rhAimPos;
        public Vector3 rhAimRot;

        Vector3 weaponLocalPos;
        Vector3 weaponLocalRot;

        public RuntimeWeapon curWeapon;

        public void Init(StateManager st)
        {
            state = st;
            anim = state.anim;

            if (shoulder == null)
                shoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder).transform;

            aimPivot = new GameObject().transform;
            aimPivot.name = "Aim Pivot";
            aimPivot.parent = state.transform;

            rightHandTarget = new GameObject().transform;
            rightHandTarget.name = "Right Hand Target";
            rightHandTarget.parent = aimPivot;

            state.movementValues.aimPosition = state.mTransform.position + transform.forward * 15;
            state.movementValues.aimPosition.y += 1.4f;  //~Height of gun

            LoadWeapon(state.inventory.curWeapon);
        }

        public void LoadWeapon(RuntimeWeapon w)
        {
            curWeapon = w;

            rhHipPos = curWeapon.rhHipfirePos;
            rhHipRot = curWeapon.rhHipfireRot;
            rhAimPos = curWeapon.rhAimingPos;
            rhAimRot = curWeapon.rhAimingRot;

            weaponLocalPos = curWeapon.weaponModelPosOffset;
            weaponLocalRot = curWeapon.weaponModelRotOffset;

            curWeapon.weaponInstance.transform.parent = anim.GetBoneTransform(HumanBodyBones.RightHand).transform;

            curWeapon.weaponInstance.transform.localPosition = weaponLocalPos;
            curWeapon.weaponInstance.transform.localEulerAngles = weaponLocalRot;


            HandleRightHandTargetTransform();
            leftHandTarget = w.weaponHook.leftHandIK;
        }
        
        public void CheckIfSheathe()
        {
            if (state.sheatheWeapon)
            {
                curWeapon.weaponInstance.transform.parent = state.backpackTransform;
                curWeapon.weaponInstance.transform.localPosition = Vector3.zero;
                curWeapon.weaponInstance.transform.localEulerAngles = Vector3.zero;
            }
            else
            {
                Transform rightHand = state.anim.GetBoneTransform(HumanBodyBones.RightHand);
                curWeapon.weaponInstance.transform.parent = rightHand;

                //USE THIS TO HELP FIND WEAPONS OFFSET VALUES 
                //curWeapon.weaponInstance.transform.LookAt(state.movementValues.aimPosition);
                //AND COMMENT THIS OUT WHEN DOING SO. UNCOMMENT FOR ACTUALY FUNCTIONALITY
                curWeapon.weaponInstance.transform.localPosition = weaponLocalPos;
                curWeapon.weaponInstance.transform.localEulerAngles = weaponLocalRot;
            }
        }

        void HandleShoulder()
        {
            HandleShoulderRotation();
            HandleShoulderPosition();
        }

        void HandleShoulderRotation()
        {
            Vector3 targetDir = lookDir;
            if (targetDir == Vector3.zero)
                targetDir = aimPivot.forward;
            Quaternion tr = Quaternion.LookRotation(targetDir);
            aimPivot.rotation = Quaternion.Slerp(aimPivot.rotation, tr, state.delta * 15); //Speed of shoulder animation rotation
        }

        void HandleShoulderPosition()
        {
            aimPivot.position = shoulder.position;
        }

        void HandleWeights()
        {
            if (state.isInteracting)
            {
                mainHandWeight = 0;
                offHandWeight = 0;
                lookWeight = 0;
                return;
            }

            if (state.isSprinting)
            {
                mainHandWeight = 0;
                offHandWeight = 1;
                lookWeight = 0;
                return;
            }

            float t_lWeight = 0;
            float t_mhWeight = 1;

            if (state.isAiming)
            {
                bodyWeight = 0.4f;
            }
            else
            {
                bodyWeight = 0.3f;
            }

            if (leftHandTarget != null)
                offHandWeight = 1;
            else
                offHandWeight = 0;

            Vector3 ld = state.movementValues.aimPosition - state.mTransform.position;
            float angle = Vector3.Angle(state.mTransform.forward, ld);
            if(angle < 76)
            {
                t_lWeight = 1;
            }
            else
            {
                t_lWeight = 0;
            }

            if (angle > 60)
                t_mhWeight = 0;

            lookWeight = Mathf.Lerp(lookWeight, t_lWeight, state.delta * 1);
            mainHandWeight = Mathf.Lerp(mainHandWeight, t_mhWeight, state.delta * 9);
        }

        private void HandleRightHandTargetTransform()
        {
            if (inIKTransition) return;

            if (CheckIKTransition())
            {
                if (state.isAiming) //now aiming but wasn't before
                {
                    StartCoroutine(IKTransition(rhAimPos, rhAimRot));
                }
                else //opposite
                {
                    StartCoroutine(IKTransition(rhHipPos, rhHipRot));
                }
            }
            else if (state.isAiming)
            {
                rightHandTarget.localPosition = rhAimPos;
                rightHandTarget.localEulerAngles = rhAimRot;
            }
            else
            {
                rightHandTarget.localPosition = rhHipPos;
                rightHandTarget.localEulerAngles = rhHipRot;
            }
        }

        bool wasAimingLastCall = false;
        private bool CheckIKTransition()
        {
            bool retValue = false;

            if(state.isAiming != wasAimingLastCall) //basically if was aiming and now isnt or opposite
            {
                retValue = true;
            }

            wasAimingLastCall = state.isAiming;
            return retValue;
        }

        float speed = 10f;
        bool inIKTransition = false;
        private IEnumerator IKTransition(Vector3 t_pos, Vector3 t_rot)
        {
            //Post transition to set ikvalue is snappy as rotation isn't lerped but with lerped rotation makes mad flips and tricks

            inIKTransition = true;
            while (Vector3.Distance(rightHandTarget.transform.localPosition, t_pos) > 0.02f)
            {
                if (CheckIKTransition()) //Basically if ik transition in interrupted
                    break;

                Vector3 actualPos = rightHandTarget.transform.localPosition;
                actualPos.x = Mathf.Lerp(actualPos.x, t_pos.x, speed * Time.deltaTime);
                actualPos.y = Mathf.Lerp(actualPos.y, t_pos.y, speed * Time.deltaTime);
                actualPos.z = Mathf.Lerp(actualPos.z, t_pos.z, speed * Time.deltaTime);

                //Vector3 actualRot = rightHandTarget.transform.localEulerAngles;
                //actualRot.x = Mathf.Lerp(actualRot.x, t_rot.x, speed * Time.deltaTime);
                //actualRot.y = Mathf.Lerp(actualRot.y, t_rot.y, speed * Time.deltaTime);
                //actualRot.z = Mathf.Lerp(actualRot.z, t_rot.z, speed * Time.deltaTime);

                rightHandTarget.transform.localPosition = actualPos;
                //rightHandTarget.transform.localEulerAngles = actualRot;

                yield return null;
            }

            inIKTransition = false;
            yield return null;
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (state.isDead)
                return;

            lookDir = state.movementValues.aimPosition - aimPivot.position;
            HandleShoulder();

            CheckIfSheathe();

            HandleWeights();
            HandleRightHandTargetTransform();

            anim.SetLookAtWeight(lookWeight, bodyWeight, 1, 1, 1);
            anim.SetLookAtPosition(state.movementValues.aimPosition);



            if (!state.isPerformingAction)
            {
                if (leftHandTarget != null)
                {
                    UpdateIK(AvatarIKGoal.LeftHand, leftHandTarget, offHandWeight);
                }

                UpdateIK(AvatarIKGoal.RightHand, rightHandTarget, mainHandWeight);
            }      
        }
       
        private void UpdateIK(AvatarIKGoal goal, Transform t, float w)
        {
            anim.SetIKPositionWeight(goal, w);
            anim.SetIKRotationWeight(goal, w);
            anim.SetIKPosition(goal, t.position);
            anim.SetIKRotation(goal, t.rotation);
        }

        public void PlayShootAnim()
        {
            anim.SetTrigger("shoot");
        }

        public void StopShootAnim()
        {
            anim.ResetTrigger("shoot");
        }

        public void PlayReloadAnim()
        {
            PlayAnimation("Reload Rifle");
        }

        public void PlayThrowGrenadeAnim()
        {
            PlayAnimation("Throw Grenade");
        }

        public void PlayRollAnimation()
        {
            PlayAnimation("Roll Forward");
        }

        public void PlayDieAnim()
        {
            PlayAnimation("Die");
        }

        public void PlayHitAnim()
        {
            PlayAnimation("Hit");
        }

        public void PlayAnimation(string animName)
        {
            anim.CrossFade(animName, 0);
        }
    }
}
