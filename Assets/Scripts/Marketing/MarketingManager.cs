using UnityEngine;
using System.Collections;

public class MarketingManager : MonoBehaviour {
    public bool isHolding = false;
    private GameObject playerObject;
    private Player playerScript;
	// Use this for initialization
	void Start () {
        playerObject = GameObject.Find("Player") as GameObject;
        playerScript = playerObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isHolding)
            playerScript.useBucket = true;
        else
            playerScript.useBucket = false;
    }
}
