using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{

    private float speed;
    private Rigidbody2D body;
    private float walkTime;
    private float speedTime;
    private int walkDir;

    public bool onFire = false;
    private float dieTime = 3f;

    // Use this for initialization
    void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        speedTime = Random.Range(1, 4);
        speed = Random.Range(1, 4);
        walkTime = Random.Range(1, 4);
        walkDir = Random.value > .5f ? 1 : -1;
    }

    // Update is called once per frame
    void Update ()
	{
        if (onFire)
        {
            DieSoon();
            return;
        }

	    if (walkTime > 0)
	    {
	        walkTime -= Time.deltaTime;
	        if (walkTime < 0)
	        {
	            walkTime = Random.Range(1, 4);
                walkDir = Random.value > .5f ? 1 : -1;
            }

        }

        if (speedTime > 0)
        {
            speedTime -= Time.deltaTime;
            if (speedTime < 0)
            {
                speedTime = Random.Range(1, 4);
                speed = Random.Range(1, 4);
            }

        }

//        Debug.Log(walkDir);
        transform.localScale = new Vector3(1f * -walkDir, 1f, 1f);
        body.velocity = new Vector2( speed * walkDir, body.velocity.y);


    }

    private void DieSoon()
    {
        dieTime -= Time.deltaTime;
        if (dieTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
