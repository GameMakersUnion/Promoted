using UnityEngine;
using System.Collections;

public class Mailroom_Shelf : MonoBehaviour {
	GameObject mailroom;

	// Use this for initialization
	void Start () {
		mailroom = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			mailroom.GetComponent<MailRoom> ().InitializeLevel ();
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
