using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public bool isOnElevator = false;
    private bool isOpen = false;
    public bool isActive = false;
    private GameObject gameManagerObject;
    private GameManager gameManager;
    private GameObject playerObject;
    private Player playerScript;
    private float elevatorSpeed = 1.0f;
    private Animator anim;
    private float elevatorOffset = 4.0f; //How far should the elevator go up
    private float elevatorStart;


    // Use this for initialization
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager") as GameObject;
        gameManager = gameManagerObject.GetComponent<GameManager>();

        playerObject = GameObject.Find("Player") as GameObject;
        playerScript = playerObject.GetComponent<Player>();

        elevatorStart = transform.position.y;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Promote();
            }
            if (isOpen && isOnElevator)
            {

                if (Mathf.Abs(transform.position.y - elevatorStart) > elevatorOffset) // We reached our floor
                {
                    //Probably play elevator music
                    playerScript.isControllable = true; //Enable the player
                    isOpen = false; // We can close up
                    isActive = false;
                }
                else
                {
                    //Probably play elevator music
                    playerScript.isControllable = false; //Disable the player
                    transform.position = new Vector2(transform.position.x, transform.position.y + elevatorSpeed * Time.deltaTime);
                    playerObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f); //Follow the Elevator
                }

                }
        }
    }

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

    public void Promote()
    {
        isOpen = true;
        gameManager.Promote(); // Increment The Level
    }
}
