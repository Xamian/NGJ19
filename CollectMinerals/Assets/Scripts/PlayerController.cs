using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed; // Floating point variable to store the player's movement speed.
    private Animator animator;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float jumpTime = 1.5f;
    [SerializeField]
    float dieRotateSpeed = 3f;
    bool jumping = false;
    bool isAlive = true;

    Collider2D coll;

    List<Collider2D> ignoredColliders = new List<Collider2D> ();

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator> ();
        coll = GetComponent<Collider2D> ();
        isAlive = true;
        jumping = false;
    }

    void Update () {
        var isIdle = true;

        //W S Foward/Backward
        if (Input.GetKey (KeyCode.W)) {
            transform.Translate (0, speed * Time.deltaTime, 0, Space.World);
            isIdle = false;
        }

        if (Input.GetKey (KeyCode.S)) {
            transform.Translate (0, -speed * Time.deltaTime, 0, Space.World);
            isIdle = false;
        }

        //A D side to side
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate (-speed * Time.deltaTime, 0, 0, Space.World);
            transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
            isIdle = false;
        }

        if (Input.GetKey (KeyCode.D)) {
            transform.Translate (speed * Time.deltaTime, 0, 0, Space.World);
            transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
            isIdle = false;
        }

        //Shooting
        if (Input.GetKeyDown (KeyCode.L)) {
            animator.SetTrigger ("Shoot");
            AudioManager.singleton.gunSound.Play ();
            EventManager.singleton.onPlayerShoot.Invoke ();
            GameObject bullet = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
            bullet.transform.localScale = transform.localScale;
            Physics2D.IgnoreCollision (GetComponent<Collider2D> (), bullet.GetComponent<Collider2D> ());
        }

        //Jumping
        if (Input.GetKeyDown (KeyCode.Space)) {
            animator.SetBool ("Jump", true);
            AudioManager.singleton.jumpSound.Play ();
            jumping = true;
            StartCoroutine (Jump ());
        }

        animator.SetBool ("IsIdle", isIdle);
    }

    IEnumerator Jump () {
        float jumpTimeLeft = jumpTime;
        while (jumpTimeLeft > 0 && Input.GetKey (KeyCode.Space)) {
            yield return new WaitForEndOfFrame ();
            jumpTimeLeft -= Time.deltaTime;

        }
        animator.SetBool ("Jump", false);
        jumping = false;
        AudioManager.singleton.jumpSound.Stop ();
        foreach (Collider2D ignoredCollider in ignoredColliders) {
            Physics2D.IgnoreCollision (coll, ignoredCollider, false);
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "PitTile" && jumping) {
            Physics2D.IgnoreCollision (coll, other.collider, true);
            ignoredColliders.Add (other.collider);
        }
    }

    private void OnCollisionStay2D (Collision2D other) {
        if (other.gameObject.tag == "PitTile" && !jumping) {
            this.enabled = false;
            StartCoroutine (Fall ());
        }
    }
    private void OnCollisionExit2D (Collision2D other) {
        if (other.gameObject.tag == "PitTile") {
            Physics2D.IgnoreCollision (coll, other.otherCollider, false);
        }
    }

    IEnumerator Fall () {
        AudioManager.singleton.fallsound.Play();
        float fallTime = 0.8f;
        float fallTimeLeft = fallTime;
        Vector3 startScale = transform.localScale;
        animator.SetTrigger ("Fall");
        while (fallTimeLeft > 0) {
            transform.localScale = startScale * (fallTimeLeft / fallTime);
            transform.Rotate (new Vector3 (0, 0, dieRotateSpeed * Time.deltaTime));
            yield return new WaitForEndOfFrame ();
            fallTimeLeft -= Time.deltaTime;
        }
        EventManager.singleton.onPlayerDie.Invoke ();
    }
}