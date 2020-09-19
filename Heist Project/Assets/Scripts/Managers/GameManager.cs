using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public static class GameManager
    {
        static ObjectPooler objectPooler;
        public static ObjectPooler GetObjectPooler()
        {
            if(objectPooler == null)
            {
                objectPooler = Resources.Load("ObjectPooler") as ObjectPooler;
                objectPooler.Init();
            }

            return objectPooler;
        }

        static ResourceManager resourcesManager;
        public static ResourceManager GetResourcesManager()
        {
            if(resourcesManager == null)
            {
                resourcesManager = Resources.Load("ResourceManager") as ResourceManager;
                resourcesManager.Init();
            }

            return resourcesManager;
        }

        static AIManager aIManager;
        public static AIManager GetAIManager()
        {
            if(aIManager == null)
            {
                aIManager = Resources.Load("AIManager") as AIManager;
            }

            return aIManager;
        }

        static MoneyManager moneyManager;
        public static MoneyManager GetMoneyManager()
        {
            if(moneyManager == null)
            {
                moneyManager = Resources.Load("MoneyManager") as MoneyManager;
            }

            return moneyManager;
        }
    }
}
