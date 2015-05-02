using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PCManager : MonoBehaviour
{

    private Bounds room;
    private Bounds pc;
    private GameObject go;
    private GameObject elevator;

    private float saturation = 0.8f;
    private List<PC> PCs; 

    

	// Use this for initialization
	void Start ()
	{

        //size of room
        room = this.GetComponent<Renderer>().bounds;

        //size of elevator
	    elevator = GameObject.Find("Elevator");
	    float eleRight = elevator.transform.position.x + elevator.GetComponent<Renderer>().bounds.extents.x;

        //size of pc
	    go = Resources.Load<GameObject>("Prefabs/PC/PC");
        pc = go.transform.Find("Rect").GetComponent<Renderer>().bounds;

        //rand spawn
        float consumed = 0f;
        Random.seed = 42;
	    float dumbConsumed = 0;

        while (consumed < saturation)
        {
            Vector3 position = new Vector3(Random.Range(-room.extents.x - eleRight, room.extents.x), 0, 0);
            Quaternion plain = Quaternion.identity;
            Instantiate(go, position, plain);

            dumbConsumed += pc.size.x;
            consumed = dumbConsumed/room.size.x;
        }
        Debug.Log(room.size + ", " + pc.size);

	}

    // Update is called once per frame
    void Update () {
	
	}
}
