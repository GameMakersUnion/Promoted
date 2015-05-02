using UnityEngine;
using System.Collections;

public class Treadmill : MonoBehaviour {
    private GameObject playerObject;
    private GameObject inputObject;
    private GameObject laundryManager;
    private Player playerScript;
    private LaundryIn laundryIn;
    private LaundryManager laundryManagerScript;
    private bool gameStart;
    private bool isComplete;
    private bool isRight;
	// Use this for initialization
	void Start () {
        //Find References of Objects
        playerObject = GameObject.Find("Player") as GameObject;
        inputObject = GameObject.Find("LaundryInput") as GameObject;
        laundryManager = GameObject.Find("LaundryManager") as GameObject;

        //Find References of Components
        playerScript = playerObject.GetComponent("Player") as Player;
        laundryIn = inputObject.GetComponent("LaundryIn") as LaundryIn;
        laundryManagerScript = inputObject.GetComponent("LaundryManager") as LaundryManager;

        gameStart = false;
        isComplete = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameStart)
        {
            //Please Mash a and d to run
            if (Input.GetKeyDown(KeyCode.A) && !isRight)
            {

                laundryIn.GenerateMoney();
                isRight = !isRight;
            }
            else if (Input.GetKeyDown(KeyCode.D) && isRight)
            {
                isRight = !isRight;
            }
            if (true) { }

        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isComplete)
        {
            playerScript.isControllable = false;
            playerObject.transform.position = transform.position;
            gameStart = true;
        }
    }
}
