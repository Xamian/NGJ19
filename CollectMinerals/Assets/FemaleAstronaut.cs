using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FemaleAstronaut : MonoBehaviour {
    [SerializeField]
    int requiredCrystals = 70;
    [SerializeField]
    Text speechbubble;
    int collectedCrystals = 0;

    // Start is called before the first frame update
    void Start () {
        speechbubble.text = "I need at least" + requiredCrystals + " crystals!";
        EventManager.singleton.onResourcePickup.AddListener (AddCrystals);
        collectedCrystals = 0;
    }

    void AddCrystals (int crystals) {
        collectedCrystals += crystals;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (collectedCrystals >= requiredCrystals) {
                EventManager.singleton.onPlayerWin.Invoke ();
                speechbubble.text = "Yay! <3";
                StartCoroutine (NextLevel ());
            }
        }
    }

    IEnumerator NextLevel () {
        yield return new WaitForSeconds (3);
        Debug.Log ("Next level!");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

}