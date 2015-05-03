using UnityEngine;
using System.Collections;

public class MailRoom : MonoBehaviour {
	GameObject player;
	Player playerScript;
	float[] posX;
	int currentPosX = 0;
	enum MailColor {Red, Green, Blue, Yellow};
	MailColor currentLetter;
	Animator anim;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = player.GetComponent<Animator> ();
		playerScript = player.GetComponent<Player> ();
		posX = new float[] {
			-0.65f, -0.15f, 0.4f, 0.95f
		};
	}
	
	// Update is called once per frame
	void Update () {
		if (playerScript.isControllable == false) {
			if (Input.GetKeyDown(KeyCode.A) && currentPosX > 0) {
				currentPosX--;
				player.transform.position = new Vector3(posX[currentPosX], player.transform.position.y, 0);
			} else if (Input.GetKeyDown(KeyCode.D) && currentPosX < 3) {
				currentPosX++;
				player.transform.position = new Vector3(posX[currentPosX], player.transform.position.y, 0);
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				ThrowMail ();
			}
		}
	}

	public void InitializeLevel () {
		playerScript.isControllable = false;
		//player.transform.position = new Vector3(posX[0], transform.position.y, 0);
		currentLetter = (MailColor)(Random.Range(0, System.Enum.GetNames(typeof(MailColor)).Length));
		switch (currentLetter) {
		case MailColor.Red:
			anim.SetBool ("isRunning", false);
			anim.Play ("Mail_Red");
			break;
		case MailColor.Green:
			anim.SetBool ("isRunning", false);
			anim.Play ("Mail_Green");
			break;
		case MailColor.Blue:
			anim.SetBool ("isRunning", false);
			anim.Play ("Mail_Blue");
			break;
		case MailColor.Yellow:
			anim.SetBool ("isRunning", false);
			anim.Play ("Mail_Yellow");
			break;
		}
	}

	void ThrowMail () {
		//if (currentLetter == ) {

		//}
	}
}
