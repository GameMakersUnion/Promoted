using UnityEngine;
using System.Collections;

public class MailBoss : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float mailForce = 12.0f;
    public int color; //0=red, 1=green, 3=blue, 4=yellow
                      // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.AddTorque(Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb);
        rb.AddForce(Vector2.up * mailForce * Time.deltaTime * Random.Range(0.9f, 1.0f), ForceMode2D.Impulse);
    }

    void SetMail()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MailDestruction")
        {
            Destroy(gameObject);
        }
    }
}
