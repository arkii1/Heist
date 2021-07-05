using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SP.UI;

namespace SP
{
    public static class GameManager
    {

        public static void LoadScene(int sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad);

            if(sceneToLoad == 0) //our gameplay scene
            {
                Debug.Log("Scene loaded");

                objectPooler.Init();
                resourcesManager.Init();
                aIManager.Init();
                moneyManager.Init();
                gameLoopManager.Init();

                if(GameObject.FindObjectOfType<UIUpdater>() != null)
                    GameObject.FindObjectOfType<UIUpdater>().Init();
            }
        }

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
                aIManager.Init();
            }

            return aIManager;
        }

        static MoneyManager moneyManager;
        public static MoneyManager GetMoneyManager()
        {
            if(moneyManager == null)
            {
                moneyManager = Resources.Load("MoneyManager") as MoneyManager;
                moneyManager.Init();
            }

            return moneyManager;
        }

        static GameLoopManager gameLoopManager;
        public static GameLoopManager GetGameLoopManager()
        {
            if(gameLoopManager == null)
            {
                gameLoopManager = Resources.Load("GameLoopManager") as GameLoopManager;
                gameLoopManager.Init();
            }

            return gameLoopManager;
        }
    }
}
