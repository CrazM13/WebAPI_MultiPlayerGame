using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * 100f * Time.deltaTime);

		Network.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

		if (Input.GetAxis("Vertical") > 0) {
			rb2d.AddForce(transform.up * 3f * Input.GetAxis("Vertical"));
		} else {
			rb2d.velocity = Vector2.zero;
		}
	}
}
