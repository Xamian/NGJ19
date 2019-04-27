using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    [SerializeField]
    Sprite deadSprite;
    [SerializeField]
    Sprite dyingSprite;

    [SerializeField]
    int hitPoints = 1;

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
            animControl.SetTrigger ("Hit");
            if (hitPoints == 1) {
                spRenderer.sprite = dyingSprite;
            }
        }
    }

    void Die () {
        spRenderer.sprite = deadSprite;
    }
}