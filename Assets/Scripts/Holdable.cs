using UnityEngine;
using System.Collections;


//drag this script onto objects you want to be holdable!

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Holdable : MonoBehaviour
{

    private Collider2D polygonCollider2d;
    private Collider2D circleCollider2d;
    private Rigidbody2D rigidbody2d;
    private Player player;
    private bool nearby = false;

    // Use this for initialization
    private void Start()
    {
        polygonCollider2d = GetComponent<PolygonCollider2D>();
        if (polygonCollider2d == null)
        {
            gameObject.AddComponent<PolygonCollider2D>();
            polygonCollider2d = GetComponent<PolygonCollider2D>();
            polygonCollider2d.isTrigger = true;
        }


        circleCollider2d = GetComponent<CircleCollider2D>();
        if (circleCollider2d == null)
        {
            gameObject.AddComponent<CircleCollider2D>();
            circleCollider2d = GetComponent<CircleCollider2D>();
            ((CircleCollider2D) circleCollider2d).radius = .1f;
        }

        rigidbody2d = GetComponent<Rigidbody2D>();
        if (rigidbody2d == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        if (nearby && player.grabbing)
        {
            this.transform.position = player.transform.position;
        }
        else
        {
//            Vector2 playerVel = player.GetComponent<Rigidbody2D>().velocity;
//            Vector2 holdableVel = this.rigidbody2d.velocity;
//            this.rigidbody2d.velocity = new Vector2(playerVel.x, holdableVel.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject.GetComponent<Player>();
            nearby = true;
        }


    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nearby = false;
        }

    }
}