﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void PlayAgainButton()
    {
        SceneManager.LoadScene(sceneName: "StartGame");
    }
}
