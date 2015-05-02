using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public bool isOnElevator = false;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			isOnElevator = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			isOnElevator = false;
		}
	}
}
