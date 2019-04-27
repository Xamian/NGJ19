using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    [SerializeField]
    float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate (transform.right * moveSpeed);
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