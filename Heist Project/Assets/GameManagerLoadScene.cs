using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP;

public class GameManagerLoadScene : MonoBehaviour
{
    public int sceneToLoad = 0;

    public void LoadScene(int sceneToLoad)
    {
        GameManager.LoadScene(sceneToLoad);
    }
}
