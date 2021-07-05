using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/Conditions/AI/Is Player In View")]
    public class IsPlayerInView : Condition
    {
        //true if is in range of a view cone plus has line of sight
        public float maxRange;
        public float maxAngle;

        int layerMask = Physics.DefaultRaycastLayers;

        public override bool CheckCondition(StateManager state)
        {
            bool retVal = false;

            if(!GameObject.FindGameObjectWithTag("Player"))
                return false;

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            
            if(Vector3.Distance(state.mTransform.position, player.transform.position) <= maxRange)
            {
                Vector3 directionBetween = (player.transform.position - state.mTransform.position).normalized;

                float angle = Vector3.Angle(state.mTransform.forward, directionBetween);

                if(angle <= maxAngle)
                {
                    Ray ray = new Ray(new Vector3(state.mTransform.position.x, state.mTransform.position.y + 1.1f, state.mTransform.position.z), directionBetween); //y offset so it is aimed at chest and not feet
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit, maxRange, layerMask))
                    {
                        if(hit.transform == player.transform)
                            retVal = true;
                    }
                }
            }

            return retVal;
        }
    }

}
