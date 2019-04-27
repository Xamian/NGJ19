using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityIntEvent : UnityEvent<int> { }

public class EventManager : MonoBehaviour {
    public UnityEvent<int> onResourcePickup = new UnityIntEvent ();
    public UnityEvent onPlayerDie = new UnityEvent ();
    public UnityEvent onWinConditionAchieved = new UnityEvent ();
    public UnityEvent onPlayerWin = new UnityEvent ();
    public UnityEvent onPause = new UnityEvent ();
    public UnityEvent onUnpause = new UnityEvent ();

    public static EventManager singleton;

    void Start () {
        if (singleton == null) {
            singleton = this;
        } else {
            Debug.LogWarning ("Multiple instances of EventManager found!", this);
        }
    }

}