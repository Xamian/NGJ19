using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    //private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        ////Get and store a reference to the Rigidbody2D component so that we can access it.
        //rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ////moves player left right up down
        //var x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
        //var y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;

        //W S Foward/Backward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
            //Debug.Log("Does Wwork?");
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
            //Debug.Log("Does Swork?");
        }

        //A D side to side
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
            //Debug.Log("Does A work?");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            //Debug.Log("Does D work?");
        }

        //rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }
}