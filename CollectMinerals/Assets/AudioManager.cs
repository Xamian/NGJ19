using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource gunSound, pickUpSound, destructableHitSound, destructableKillSound;
    public AudioSource[] walkSound;

    public static AudioManager singleton;

    void Start () {
        if (singleton == null)
            singleton = this;
        else Debug.LogWarning ("Multiple auidio managers detected!", this);
    }
}