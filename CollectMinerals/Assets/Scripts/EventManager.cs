using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {
    public static UnityEvent<int> onResourcePickup;
    public static UnityEvent onPlayerDie;
    public static UnityEvent onWinConditionAchieved;
    public static UnityEvent onPlayerWin;
    public static UnityEvent onPause;
    public static UnityEvent onUnpause;

}