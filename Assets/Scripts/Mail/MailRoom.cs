using UnityEngine;
using System.Collections;

public class MailRoom : MonoBehaviour {
	GameObject player;
    private GameObject mailroomShelf;
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
    public GameObject elevator;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
        mailroomShelf = GameObject.Find("Mailroom_Shelf") as GameObject;
        anim = player.GetComponent<Animator> ();
		playerScript = player.GetComponent<Player> ();
		posX = new float[] {
			mailroomShelf.transform.position.x-0.65f, mailroomShelf.transform.position.x-0.15f, mailroomShelf.transform.position.x+0.4f, mailroomShelf.transform.position.x+0.95f
		};
        //elevator = gameObject.pare
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
    void SpawnMail(MailColor color)
    {
        switch (color)
        {
            case MailColor.Blue:
                Instantiate(Resources.Load("Prefabs/MailRed"), player.transform.position, Quaternion.identity);
                break;
            case MailColor.Green:
                Instantiate(Resources.Load("Prefabs/MailGreen"), player.transform.position, Quaternion.identity);
                break;
            case MailColor.Red:
                Instantiate(Resources.Load("Prefabs/MailRed"), player.transform.position, Quaternion.identity);
                break;
            case MailColor.Yellow:
                Instantiate(Resources.Load("Prefabs/MailYellow"), player.transform.position, Quaternion.identity);
                break;
        }
    }
	void ThrowMail () {
		if (currentLetter == (MailColor)currentPosX) {
			score++;
            SpawnMail(currentLetter);
            currentLetter = (MailColor)(Random.Range (0, System.Enum.GetNames (typeof(MailColor)).Length));
            animName = "Mail_" + currentLetter;
			anim.SetBool ("isRunning", false);
			anim.Play (animName);
			if (score >= scoreGoal) {
                Debug.Log("Promoted");
                playerScript.isControllable = true;
                isActive = false;
                // PROMOTED
                GetComponentInChildren<Elevator>().Promote();
                //elevator.gameObject.GetComponent<Elevator>().Promote();
            }
		} else {
			// DEMOTED
		}
	}
}
