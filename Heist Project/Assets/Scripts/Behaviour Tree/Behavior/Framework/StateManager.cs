using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using UnityEngine.AI;

namespace SP
{
    public class StateManager : MonoBehaviour, IDamageable
    {
        #region Variables

        public StateManagerType type;

        #region References

        [HideInInspector]
        public MovementValues movementValues;

        public State currentState;

        #region Assigned Via Code

        [HideInInspector]
        public Transform mTransform;

        [HideInInspector]
        public Rigidbody rb;

        [HideInInspector]
        public Animator anim;

        [HideInInspector]
        public float delta;

        [HideInInspector]
        public LayerMask ignoreLayers;

        [HideInInspector]
        public AnimatorHook animHook;

        [HideInInspector]
        public NavMeshAgent agent;

        #endregion

        #region Assigned Via Editor

        public StateAction initStateActionBatch;

        public Inventory inventory;

        public Transform backpackTransform;

        #endregion

        #endregion

        #region Bools 
        //wants to is for triggered bools, is is for continuous interchanging bools

        public bool wantsToShoot; 
        public bool wantsToReload;
        public bool wantsToThrowGrenade;
        public bool wantsToRoll;
        public bool wantsToInteract;

        public bool isAiming;
        public bool isSprinting;
        public bool isCrouching;

        //these are not set by input
        public bool isInteracting;
        public bool isPerformingAction;

        public bool sheatheWeapon;

        public bool isDead = false;
        #endregion

        #region Floats

        public float currentHealth;
        public float maxHealth;

        #endregion

        #endregion

        #region Sub-classes

        [System.Serializable]
        public class MovementValues
        {
            public float horizontal;
            public float vertical;
            public float moveAmount;

            public Vector3 moveDirection;
            public Vector3 lookDirection;
            public Vector3 aimPosition;
        }

        #endregion

        #region Methods
        private void Awake()
        {
            mTransform = this.transform;

            anim = GetComponent<Animator>();

            if(GetComponent<Rigidbody>() != null)
            {
                rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                rb.angularDrag = 999;
                rb.drag = 4;
            }
            
            if(GetComponent<NavMeshAgent>() != null)
                agent = GetComponent<NavMeshAgent>();

            ignoreLayers = ~(1 << 9 | 1 << 3);

            inventory.Init();

            if (initStateActionBatch != null)
                initStateActionBatch.Execute(this);

            currentHealth = maxHealth;
        }

        private void Update()
        {
            delta = Time.deltaTime;

            if(currentState != null)
            {
                currentState.UpdateTick(this);
            }

        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;

            if(currentState != null)
            {
                currentState.FixedUpdateTick(this);
            }
        }

        public void TakeDamage(float damage, ContactPoint contactPoint)
        {
            currentHealth -= damage;
            animHook.PlayHitAnim();

            GameObject hitParticle = GameManager.GetObjectPooler().RequestObject("BloodSplatter");
            hitParticle.transform.position = contactPoint.point;
            hitParticle.transform.forward = contactPoint.normal;
        }
        #endregion
    }

    public enum StateManagerType
    {
        player, guard, npc
    }
}

