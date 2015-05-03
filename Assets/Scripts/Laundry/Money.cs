using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour {
    private SpriteRenderer render;
    public float duration = 5; //Time the money is dirty
    private float startTime;
    private float timeFactor;
    private float spawnForce = 250.0f; //The force that the money is shot out
    private float laundryForce = 0.5f; //The force that the money is spun
    private float spawnTorque = 3.0f;
    private Rigidbody2D rb;
    private bool isComplete = false;
    private GameObject output;
    private GameObject accountPipe;
    private GameObject laundryManager;
    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        render.color = new Color(0.2F, 0.2F, 0.2F, 1.0F);
        startTime = Time.time;
        timeFactor = 0;
        rb.AddForce(Vector2.right * spawnForce);
        rb.AddTorque(spawnTorque * Random.Range(-2, 2));
        output = GameObject.Find("LaundryOutput");
        laundryManager = GameObject.Find("LaundryManager");
        rb.gravityScale = 1.0f;

    }
	
	// Update is called once per frame
	void Update () {
        timeFactor = (Time.time - startTime)/duration - 0.2f;
        render.color = new Color((0.2f + timeFactor), (0.2f + timeFactor), (0.2f + timeFactor), 1.0f);
        //if(!isComplete)
        //   rb.AddForce(WashingMachineForce() * laundryForce, ForceMode2D.Impulse);
        if(timeFactor > 1.0f && !isComplete)
        {
            rb.gravityScale = 1.0f;
            if (output != null)
            {
                transform.position = output.transform.position;
                rb.AddForce(Vector2.right * spawnForce * 1.85f);
            }
            LaundryManager lm = laundryManager.GetComponent("LaundryManager") as LaundryManager;
            lm.MoneyCleaned();
            Debug.Log(lm);
            isComplete = true;
        }
    }

    Vector2 WashingMachineForce()
    {
        int direction = Mathf.RoundToInt(Time.time) % 8;
        Vector2 dir = new Vector2(1.0f, 0.0f);
        switch (direction)
        {
            case 0: dir =  new Vector2(1.0f,0.0f); break;
            case 1: dir = new Vector2(1.0f, 1.0f); break;
            case 2: dir = new Vector2(0.0f, 1.0f); break;
            case 3: dir = new Vector2(-1.0f, 1.0f); break;
            case 4: dir = new Vector2(-1.0f, 0.0f); break;
            case 5: dir = new Vector2(1.0f, -1.0f); break;
            case 6: dir = new Vector2(0.0f, -1.0f); break;
            case 7: dir = new Vector2(1.0f, -1.0f); break;
        }
        return dir.normalized;
    }
}
