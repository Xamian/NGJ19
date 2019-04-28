using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEvents : MonoBehaviour {
    int audioIndex = 0;
    public void FootStep () {
        Debug.Log ("Step!");
        AudioSource[] audioFiles = AudioManager.singleton.walkSound;
        int playIndex;
        do {
            playIndex = Random.Range (0, audioFiles.Length);
        } while (playIndex == audioIndex);

        audioFiles[playIndex].Play ();
    }
}