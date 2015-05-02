using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 1;
	public float jumpPower = 1;
	Rigidbody2D body;
	int layerMask = 1 << 2;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
		layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		// Horizontal movement
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.localScale = new Vector3(1f,1f,1f);
			body.velocity = new Vector2(-speed, body.velocity.y);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.localScale = new Vector3(-1f,1f,1f);
			body.velocity = new Vector2(speed, body.velocity.y);
		}
		// Vertical movement
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (Physics2D.Raycast(transform.position, Vector3.down, 0.55f, layerMask)) {
				body.AddForce (new Vector2 (0, jumpPower), ForceMode2D.Impulse);
			}
		}
	}
}
