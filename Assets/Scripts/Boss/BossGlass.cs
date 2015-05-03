using UnityEngine;
using System.Collections;

public class BossGlass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        //if(coll.gameObject.tag == "Boss")
            SoundManager.Play(SoundManager.Sounds.GlassBreak);
    }
}
