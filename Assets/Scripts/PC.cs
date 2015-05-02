using UnityEngine;
using System.Collections;

public class PC : MonoBehaviour
{

    private BoxCollider2D box;
    private SpriteRenderer renderer;
    private bool nearby = false;
    private Player player;

    private const float timeToBoot = 3f;
    private float timeToCrash;
    private float timeRunning = 0;
    

    // Use this for initialization
    void Start () {
        box = gameObject.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        player =  GameObject.FindWithTag("Player").GetComponent<Player>();
        Random.seed = 42;
        timeToCrash = Random.Range(timeToBoot + 1f, timeToBoot + 10f);
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        //do main logic here
        if (nearby && player.activating)
        {
             this.renderer.color = Color.blue;
            
        }


    }

    void Crashing()
    {
        
    }

    void Rebooting()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
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
