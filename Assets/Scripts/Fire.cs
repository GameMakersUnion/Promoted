using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{

    private bool firing = false;
    private float burnTime = 2f;
    private float sitUnusedTime = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (firing)
	    {
	        RemoveMatchSoonBurning();
	    }
	    else
	    {
	        RemoveMatchSoonSitting();
	    }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("NPC") && !firing)
        {
            GameObject fire = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/FirePerson"), other.transform.position, Quaternion.identity);
            //Destroy(hit.transform.gameObject);
            other.GetComponent<NPC>().onFire = true;
            fire.transform.parent = other.transform;

            float x = Random.Range(-1, 1);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x, -50);

            firing = true;
            transform.parent.GetComponent<FireCastManager>().firedCount++;

        }
    }


    void RemoveMatchSoonBurning()
    {
        burnTime -= Time.deltaTime;
        if (burnTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void RemoveMatchSoonSitting()
    {
        sitUnusedTime -= Time.deltaTime;
        if (sitUnusedTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    //    void OnTriggerStay2D(Collider2D other)
    //    {
    //        if (other.gameObject.layer == "NPC")
    //        {
    //            playerInside = true;
    //        }
    //    }

    //    private void OnTriggerExit2D(Collider2D other)
    //    {
    //        if (other.gameObject.layer == "NPC")
    //        {
    //            playerInside = false;
    //        }
    //    }
}
