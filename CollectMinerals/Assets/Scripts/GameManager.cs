using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool paused = false;
    public static bool isAlive = true;
    public static bool gameActive = true;
    [SerializeField]
    GameObject gameOverText;

    void Start () {
        EventManager.singleton.onPlayerDie.AddListener (ShowGameOver);
        gameOverText.SetActive (false);
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.Return)) {
            if (!isAlive) {
                SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
                isAlive = true;
                gameActive = true;
                paused = false;
                return;
            }
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

    void ShowGameOver () {
        isAlive = false;
        gameOverText.SetActive (true);
    }

}