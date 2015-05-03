using UnityEngine;
using System.Collections;

public class TextMatching : MonoBehaviour {
    private GUIText other;
    private GUIText me;
    private string data;
	// Use this for initialization
	void Start () {
       other = GetComponentInParent<GUIText>();
        me = GetComponent< GUIText > ();
    }
	
	// Update is called once per frame
	void Update () {
        me.text = other.text;
	}
}
