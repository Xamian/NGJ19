using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int pointsToWin = 100;
    public int currentPoints = 0;
    public float startOxygen = 60f;
    float currentOxygen;

    // Start is called before the first frame update
    void Start () {
        EventManager.singleton.onResourcePickup.AddListener (CheckForWinCondition);
        currentOxygen = startOxygen;
    }

    void Update () {
        if (GameManager.gameActive && !GameManager.paused) {
            currentOxygen -= Time.deltaTime;
            if (currentOxygen < 0) {
                EventManager.singleton.onPlayerDie.Invoke ();
                GameManager.gameActive = false;
            }
        }
    }

    void CheckForWinCondition (int resourcesAdded) {
        currentPoints += resourcesAdded;
        if (resourcesAdded >= pointsToWin) {
            EventManager.singleton.onWinConditionAchieved.Invoke ();
        }
    }

}