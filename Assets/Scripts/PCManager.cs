using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PCManager : MonoBehaviour
{
    protected List<PC> PCs = new List<PC>(); //populated from each child PC.
    private const int goalReboots = 15;
    public int reboots = 0;

	// Use this for initialization
	void Start ()
	{
        //rand time
        //Random.seed = 42;


	}

    // Update is called once per frame
    void Update () {

    }
}
