﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool paused = false;
    public static bool gameActive = true;

    void Update () {
        if (Input.GetKeyDown (KeyCode.Return)) {
            paused = !paused;
            if (paused) {
                Time.timeScale = 0f;
                EventManager.singleton.onPause.Invoke ();
            } else {
                EventManager.singleton.onUnpause.Invoke ();
                Time.timeScale = 1f;
            }

        }
    }

}