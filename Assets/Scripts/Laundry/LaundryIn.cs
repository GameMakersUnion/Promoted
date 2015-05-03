using UnityEngine;
using System.Collections;

public class LaundryIn : MonoBehaviour {
    GameObject prefab;
   
	// Use this for initialization
	void Start () {
	    prefab = Resources.Load("Prefabs/Laundry/Money") as GameObject;
        
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void GenerateMoney()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
