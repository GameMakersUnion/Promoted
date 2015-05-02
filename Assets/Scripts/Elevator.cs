using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public bool isOnElevator = false;

	void OnTriggerEnter () {
		isOnElevator = true;
	}

	void OnTriggerExit () {
		isOnElevator = false;
	}
}
