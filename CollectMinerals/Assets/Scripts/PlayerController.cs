using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed; // Floating point variable to store the player's movement speed.
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var isIdle = true;

        //W S Foward/Backward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
            isIdle = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
            isIdle = false;
        }

        //A D side to side
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            isIdle = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            isIdle = false;
        }

        animator.SetBool("IsIdle", isIdle);
    }
}