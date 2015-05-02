using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public float speed = 4;
	public float jumpPower = 10;
	Rigidbody2D body;
	int layerMask = 1 << 2;
    public bool isControllable; //I know public access is bad, =P - Victor

    private enum Action {  Left, Right, Jump, Elevate, Action1, Hold };

    private Dictionary<Action, KeyCode> Do = new Dictionary<Action, KeyCode>()
    {
        {Action.Left, KeyCode.A },
        {Action.Right, KeyCode.D },
        {Action.Jump, KeyCode.Space},
        {Action.Elevate, KeyCode.W },
        {Action.Action1, KeyCode.F },
        {Action.Hold, KeyCode.LeftShift}
    };

    private float legs;

    // Use this for initialization
    void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
		layerMask = ~layerMask;
        isControllable = true;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    legs = this.GetComponent<Renderer>().bounds.extents.y;
	}

    void FixedUpdate()
    {
        if (isControllable) { 
            // Horizontal movement
            if (Input.GetKey(Do[Action.Left]))
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                body.velocity = new Vector2(-speed, body.velocity.y);
            }
            else if (Input.GetKey(Do[Action.Right]))
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                body.velocity = new Vector2(speed, body.velocity.y);
            }
            // Vertical movement
            if (Input.GetKeyDown(Do[Action.Jump]))
            {
                if (Physics2D.Raycast(transform.position, Vector3.down, legs*1.1f, layerMask))
                {
                    body.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                }
            }
            // Elevate 
            if (Input.GetKey(Do[Action.Elevate]))
            {
                //liam does this
            }

            // Action1 (launch mail)
            if (Input.GetKeyDown(Do[Action.Action1]))
            {
                //get from script attached to level Action Map
            }

            // Hold 
            if (Input.GetKey(Do[Action.Hold]))
            {
            
            }
        }
    }
}
