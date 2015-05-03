using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public float speed = 4;
	public float jumpPower = 10;
    public bool useBucket;
	Rigidbody2D body;
	int layerMask = ((1 << 2) | (1 << 9));
    public bool isControllable; //I know public access is bad, =P - Victor
	Animator anim;

    private enum Action {  Left, Right, Jump, Elevate, Action1, Grab };

    private Dictionary<Action, KeyCode> Do = new Dictionary<Action, KeyCode>()
    {
        {Action.Left, KeyCode.A },
        {Action.Right, KeyCode.D },
        {Action.Jump, KeyCode.Space},
        {Action.Elevate, KeyCode.W },
        {Action.Action1, KeyCode.F },
        {Action.Grab, KeyCode.LeftShift}
    };

    private float legs;
    private bool grabbing_ = false;
    public bool grabbing { get { return grabbing_; }  }
    private bool activating_ = false;
    public bool activating { get { return activating_; } }


    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
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
        if (isControllable)
        {
            // Horizontal movement
            if (Input.GetKey(Do[Action.Left]))
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                body.velocity = new Vector2(-speed, body.velocity.y);
                anim.SetBool("isRunning", true);
                if (useBucket)
                    anim.SetBool("useBucket", true);
                else
                    anim.SetBool("useBucket", false);
            }
            else if (Input.GetKey(Do[Action.Right]))
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                body.velocity = new Vector2(speed, body.velocity.y);
                anim.SetBool("isRunning", true);
                if (useBucket)
                    anim.SetBool("useBucket", true);
                else
                    anim.SetBool("useBucket", false);
            }
            else
            {
                anim.SetBool("isRunning", false);
                if (useBucket) { 
                    anim.SetBool("useBucket", true);
                    anim.Play("IdleBucket");
                }
                else { 
                    anim.SetBool("useBucket", false);
                    anim.Play("Idle");
                }
                
                
            }
            // Vertical movement
            if (Input.GetKeyDown(Do[Action.Jump]))
            {
                RaycastHit2D other = Physics2D.Raycast(transform.position, Vector3.down, legs*1.1f, layerMask);
                if (other)
                {
//                    Debug.Log(other.collider.gameObject.layer);
                    if (!other.collider.isTrigger) //No more wall jumping on triggers =P - Vic
                        if (!other.collider.GetComponentInChildren<Collider2D>().isTrigger) //No more wall jumping on triggers =P - Vic
                            body.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                }
            }
            // Elevate 
            if (Input.GetKey(Do[Action.Elevate]))
            {
                //liam does this
            }

            // Action1 (launch mail)
            activating_ = (Input.GetKeyDown(Do[Action.Action1]));

            // Hold 
            grabbing_ = (Input.GetKey(Do[Action.Grab]));

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
