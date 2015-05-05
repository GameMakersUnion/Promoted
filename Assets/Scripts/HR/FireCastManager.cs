using UnityEngine;
using System.Collections;

public class FireCastManager : MonoBehaviour
{

    private GameObject player;
    public bool playerInside = false;
    private const float FIRE_GOAL = 15;
    public float firedCount = 0;
    private bool hasWon = false;


    // Use this for initialization
    void Start ()
	{
	    player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update () {
        
        //exit early
        if (hasWon)
        {
            return;
        }


        bool okFire = this.GetComponent<FireCastManager>().playerInside;

        if (okFire && player.GetComponent<Player>().activating )
	    {
            Debug.Log("activating fire");

            //throw object
//	        GameObject matchP = (GameObject)Resources.Load("Prefabs/Shapes/Square");
	        GameObject matchP = (GameObject)Resources.Load("Prefabs/1x6 pixel match");

            GameObject match = (GameObject)Instantiate(matchP, player.transform.position, Quaternion.identity);

	        float dir = player.GetComponent<Rigidbody2D>().velocity.normalized.x;

	        match.AddComponent<BoxCollider2D>();
	        match.GetComponent<BoxCollider2D>().isTrigger = true;
	        match.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
	        match.AddComponent<Rigidbody2D>();
            match.GetComponent<Rigidbody2D>().AddForce(new Vector2(4 * dir, 1) * 100f);
            match.GetComponent<Rigidbody2D>().AddTorque(500f);
            match.AddComponent<Fire>();
	        match.transform.parent = this.transform;
            SoundManager.Play(SoundManager.Sounds.FireWoosh);
	    }

        //activate win cond:
        if (firedCount > FIRE_GOAL && !hasWon)
        {
            Debug.Log("WON");
            hasWon = true;
            GetComponentInChildren<Elevator>().Promote();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }

}
