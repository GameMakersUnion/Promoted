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
	bool isActive = false;
	int score = 0;
	int scoreGoal = 5;
	string animName;

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
		if (!playerScript.isControllable && isActive) {
			if (Input.GetKeyDown(KeyCode.A) && currentPosX > 0) {
				currentPosX--;
				player.transform.localScale = new Vector3 (1,1,1);
				player.transform.position = new Vector3(posX[currentPosX], player.transform.position.y, 0);
			} else if (Input.GetKeyDown(KeyCode.D) && currentPosX < 3) {
				currentPosX++;
				player.transform.localScale = new Vector3 (-1,1,1);
				player.transform.position = new Vector3(posX[currentPosX], player.transform.position.y, 0);
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				ThrowMail ();
			}
		}
	}

	public void InitializeLevel () {
		isActive = true;
		playerScript.isControllable = false;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		player.transform.position = new Vector3(posX[currentPosX], player.transform.position.y, 0);
		currentLetter = (MailColor)(Random.Range (0, System.Enum.GetNames (typeof(MailColor)).Length));
		animName = "Mail_" + currentLetter;
		anim.SetBool ("isRunning", false);
		anim.Play (animName);
	}

	void ThrowMail () {
		if (currentLetter == (MailColor)currentPosX) {
			score++;
			currentLetter = (MailColor)(Random.Range (0, System.Enum.GetNames (typeof(MailColor)).Length));
			animName = "Mail_" + currentLetter;
			anim.SetBool ("isRunning", false);
			anim.Play (animName);
			if (score == scoreGoal) {
				// PROMOTED
			}
		} else {
			// DEMOTED
		}
	}
}
