using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : MonoBehaviour {
    [SerializeField]
    int resources = 10;
    [SerializeField]
    Sprite emptySprite;
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            EventManager.onResourcePickup.Invoke (resources);
            GetComponent<SpriteRenderer> ().sprite = emptySprite;
            Destroy (this);
        }
    }
}