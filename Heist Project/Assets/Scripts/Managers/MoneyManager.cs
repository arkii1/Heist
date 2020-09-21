using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    [CreateAssetMenu(menuName = "Managers/Money Manager")]
    public class MoneyManager : ScriptableObject
    {
        public int currentMonies = 0;

        public void Init()
        {
            currentMonies = 0;
        }

        public void AddMoney(int moneyToAdd)
        {
            currentMonies += moneyToAdd;
        }

    }
}

