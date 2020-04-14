using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public static BackgroundLoop instance;

    //the if else statment prevents a music loop from duplicating everytime a scene is switched
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
