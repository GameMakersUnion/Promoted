using UnityEngine;
using System.Collections;


//drag this script onto objects you want to be holdable!

public class Holdable : MonoBehaviour
{
    private bool isHolding = false;
    private GameObject player;
    private Player playerScript;
    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    private float throwForce = 10.0f;
    private float throwDelay =0.25f;
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
            if (playerScript.lettingGo)
            {
                Throw();
            }
        }
    }

    public bool PickUp()
    {
        if (Time.time - pickupTime > throwDelay)
        {
            if (GetComponent<Paint>().throws > 0) {
                isHolding = true;
                pickupTime = Time.time;
                rb.isKinematic = true;
                return true;
            }
            return false;
        }
        return false;
    }

    public void Throw()
    {
        
            isHolding = false;
            rb.isKinematic = false;
            GetComponentInParent<MarketingManager>().isHolding = false;
            GetComponentInChildren<Pickup>().gameObject.layer = 1;
            GetComponent<Paint>().Thrown();
            //Vector2 throwDirection = new Vector2(playerRb.velocity.normalized.x,0.0f) ;
            Vector2 throwDirection = new Vector2(playerRb.velocity.normalized.x, playerRb.velocity.normalized.y);
            rb.AddForce(throwDirection * throwForce + Vector2.up * 6.0f, ForceMode2D.Impulse);
        

    }

}