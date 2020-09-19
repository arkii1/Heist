using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float destroyDelay = 5;

    private void Start()
    {
        Destroy(gameObject, destroyDelay);   
    }
}
