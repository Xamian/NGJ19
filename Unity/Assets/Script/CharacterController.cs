using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	[SerializeField]
	float movementPower = 10f;
	float verticalMovement, horizontalMovement;
	Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		horizontalMovement = Input.GetAxis ("Horizontal");
		verticalMovement = Input.GetAxis ("Vertical");
	}

	void FixedUpdate () {
		Vector3 globalMoveDir = transform.right * horizontalMovement + transform.forward * verticalMovement;
		Debug.DrawLine (transform.position, transform.position + globalMoveDir * 2, Color.green);
		rigid.AddForce (globalMoveDir * movementPower, ForceMode.Force);
	}

}