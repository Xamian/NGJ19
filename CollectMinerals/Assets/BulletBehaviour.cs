using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float lifeTime = 5f;

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate (transform.right * moveSpeed);
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime >= 0) {
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D collisionInfo) {
        Debug.Log ("Hit!");
        Destructable hitDestrucable = collisionInfo.gameObject.GetComponent<Destructable> ();
        if (hitDestrucable != null) {
            hitDestrucable.Hit ();
        }
        Destroy (gameObject);
    }
}