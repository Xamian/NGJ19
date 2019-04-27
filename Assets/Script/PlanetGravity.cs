using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequiresComponent (typeof (Rigidbody))]
public class PlanetGravity : MonoBehaviour {

	[SerializeField]
	Transform planet;
	[SerializeField]
	float gravityForce = 9.02f;
	Rigidbody rigid;
	Collider coll;
	bool onGround = false;

	// Use this for initialization
	void Start () {
		coll = GetComponent<Collider> ();
		rigid = GetComponent<Rigidbody> ();
		rigid.useGravity = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 planetGravity = planet.position - transform.position;
		rigid.AddForce (planetGravity.normalized * gravityForce, ForceMode.Acceleration);
		transform.LookAt (transform.position + transform.forward, -planetGravity);
		if (Physics.Raycast (transform.position - transform.up * coll.bounds.extents.y, planetGravity, 0.2f)) {

		}

	}
}