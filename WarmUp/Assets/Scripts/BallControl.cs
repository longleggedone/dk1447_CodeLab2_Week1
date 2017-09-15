using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 velocity;
	private Vector2 lastPos;
	public float speed = 20f;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("Move", 1);
	}
		
	void FixedUpdate(){
		Vector3 pos3D = transform.position;
		Vector2 pos2D = new Vector2(pos3D.x, pos3D.y);

		velocity = pos2D - lastPos;
		lastPos = pos2D;
	}

	// Update is called once per frame
	void Move () {
		//rb2d.AddForce(transform.up * speed);
		rb2d.velocity = Random.insideUnitCircle.normalized * speed;
	}

	void OnCollisionEnter2D (Collision2D col) {

		Vector3 normal = col.contacts[0].normal;

		Vector3 direction = velocity;

		Vector3 reflection = Vector3.Reflect(direction, normal).normalized;

		rb2d.velocity = new Vector2 (reflection.x, reflection.y) * speed;
	}
}
