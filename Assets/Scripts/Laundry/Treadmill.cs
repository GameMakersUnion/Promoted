using UnityEngine;
using System.Collections;

public class Treadmill : MonoBehaviour {
    private GameObject playerObject;
    private GameObject inputObject;
    private GameObject laundryManager;
    private Player playerScript;
    private LaundryIn laundryIn;
    private LaundryManager laundryManagerScript;
    private Rigidbody2D playerRb;
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
        laundryManagerScript = laundryManager.GetComponentInParent<LaundryManager>();
        playerRb = playerObject.GetComponent("Rigidbody2D") as Rigidbody2D;

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
            

        }
//        Debug.Log(laundryManagerScript.MoneyCount() + " " + laundryManagerScript.goal);
         if (laundryManagerScript.MoneyCount() > laundryManagerScript.goal && !isComplete)
        {
            Debug.Log("Promoted");
            gameStart = false;
            laundryManager.GetComponentInChildren<Elevator>().Promote();
            playerScript.isControllable = true;
            isComplete = true;
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isComplete && !gameStart)
        {
            playerScript.isControllable = false;
            playerRb.velocity = Vector2.zero;
            playerObject.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y+0.3f);
            gameStart = true;
        }
    }
}
