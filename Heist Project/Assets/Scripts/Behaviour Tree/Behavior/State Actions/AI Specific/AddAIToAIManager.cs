using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "SP/State Actions/AI/Add AI To AI Manager")]
    public class AddAIToAIManager : StateAction
    {
        public override void Execute(StateManager state)
        {
            switch (state.type)
            {
                case StateManagerType.player:
                    break;
                case StateManagerType.guard:
                    GameManager.GetAIManager().AddGuard(state);
                    break;
                case StateManagerType.npc:
                    GameManager.GetAIManager().AddNPC(state);
                    break;
                default:
                    break;
            }

        }
    }
}
