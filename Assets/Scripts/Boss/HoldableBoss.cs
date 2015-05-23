using UnityEngine;
using System.Collections;

public class HoldableBoss : MonoBehaviour {

    private bool isHolding = false;
    private GameObject player;
    private Player playerScript;
    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    private float throwForce = 1000.0f;
    private float throwDelay = 0.25f;
    private float pickupTime;

    // Use this for initialization
    private void Start()
    {
        player = GameObject.Find("Player") as GameObject;
        playerScript = player.GetComponent<Player>();
        playerRb = player.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isHolding)
        {
            transform.position = player.transform.position;
            if (playerScript.activating)
            {
                Throw();
            }
        }
    }

    public void PickUp()
    {
        //if (GetComponent<Paint>().throws > 0)
        {
            isHolding = true;
            pickupTime = Time.time;
            rb.isKinematic = true;
        }
    }

    public void Throw()
    {
        if (Time.time - pickupTime > throwDelay)
        {
            isHolding = false;
            rb.isKinematic = false;
            GetComponentInParent<BossManager>().isHolding = false;
            GetComponentInChildren<PickupBoss>().gameObject.layer = 1;
            //GetComponent<Paint>().Thrown();
            //Vector2 throwDirection = new Vector2(playerRb.velocity.normalized.x,0.0f) ;
            Vector2 throwDirection = new Vector2(playerRb.velocity.normalized.x, playerRb.velocity.normalized.y);
            rb.AddForce(Vector2.right * throwForce, ForceMode2D.Impulse);
        }

    }
}
