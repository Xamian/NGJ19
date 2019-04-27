using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    [SerializeField]
    Sprite deadSprite;
    [SerializeField]
    Sprite dyingSprite;

    [SerializeField]
    int hitPoints = 5;

    [SerializeField]
    int weakHitPointLimit = 2;

    Animator animControl;

    SpriteRenderer spRenderer;

    void Start () {
        spRenderer = GetComponent<SpriteRenderer> ();
        animControl = GetComponent<Animator> ();
    }

    public void Hit () {
        hitPoints--;
        if (hitPoints <= 0) {
            Die ();
        } else {
            AudioManager.singleton.destructableHitSound.Play ();
            animControl.SetTrigger ("Hit");
            if (hitPoints == weakHitPointLimit) {
                spRenderer.sprite = dyingSprite;
            }
        }
    }

    void Die () {
        AudioManager.singleton.destructableKillSound.Play ();
        spRenderer.sprite = deadSprite;
        Destroy (GetComponent<Collider2D> ());
    }
}