using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int pointsToWin = 100;
    public int currentPoints = 0;

    // Start is called before the first frame update
    void Start () {
        EventManager.onResourcePickup.AddListener (CheckForWinCondition);
    }

    void CheckForWinCondition (int resourcesAdded) {
        currentPoints += resourcesAdded;
        if (resourcesAdded >= pointsToWin) {
            EventManager.onWinConditionAchieved.Invoke ();
        }
    }

}