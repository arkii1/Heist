using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/Player Specific/Ground State Manager")]
    public class GroundStateManager : StateAction
    {
        public override void Execute(StateManager state)
        {
            Vector3 origin = state.mTransform.position;
            origin.y += 1;
            Vector3 dir = Vector3.down;
            Ray ray = new Ray(origin, dir);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1.4f, state.ignoreLayers))
            {
                state.mTransform.position = new Vector3(state.mTransform.position.x, 
                                                        hit.point.y, 
                                                        state.mTransform.position.z);
            }
            else
            {
                state.rb.velocity += Vector3.down * 9.81f;
            }
        }
    }
}

