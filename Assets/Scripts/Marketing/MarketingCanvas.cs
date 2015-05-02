using UnityEngine;
using System.Collections;

public class MarketingCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "MarketingPaint")
        {

        }
    }
}
