using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	int timeLimit, currentTime;
	Text text1, text2;
	// Use this for initialization
	void Start () {
		timeLimit = GameObject.Find ("GameManager").GetComponent<GameManager> ().timeLimit;
		text1 = gameObject.GetComponent<Text> ();
		text2 = transform.Find ("Outline").GetComponent<Text> ();

	}
	// Update is called once per frame
	void Update () {
		currentTime = timeLimit - (int)Time.time;
		if (currentTime > 0) {
			text1.text = currentTime.ToString ();
			text2.text = currentTime.ToString ();
		} else {
			// GAME OVER
		}
	}
}
