﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PlayGame was pressed");
        SceneManager.LoadScene("Game");
    }
}
