using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "Managers/Game Loop Manager")]
    public class GameLoopManager : ScriptableObject
    {
        public GameLoopPhase phase;

        public void Init()
        {
            phase = GameLoopPhase.preAlarmPhase;
        }

        public void ActivateAlarm()
        {
            phase = GameLoopPhase.alarmedPhase;
        }

        public void PlayerHasEscaped()
        {
            phase = GameLoopPhase.escapedPhase;

            //Pause game, show post game menu, save high score
        }
    }

    public enum GameLoopPhase
    {
        preAlarmPhase, alarmedPhase, escapedPhase
    }
}
