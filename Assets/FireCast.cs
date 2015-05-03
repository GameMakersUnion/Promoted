using UnityEngine;
using System.Collections;

public class FireCast : MonoBehaviour
{

    private GameObject player;

	// Use this for initialization
	void Start ()
	{
	    player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (player.GetComponent<Player>().activating)
	    {
            Debug.Log("activating");
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.right);
            Debug.DrawRay(player.transform.position, Vector2.right, Color.green);

            if (hit)
	        {
                float distanceToEnemy = hit.distance;
	            Instantiate(Resources.Load<SpriteRenderer>("Prefabs/FirePerson"), hit.transform.position,
	                Quaternion.identity);
                Destroy(hit.transform.gameObject);
                if (hit.transform.GetComponent<NPC>() != null)
	            {
                    Debug.Log("hit npc@");
                }

            }
        }
    }
}
