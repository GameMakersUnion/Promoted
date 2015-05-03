using UnityEngine;
using System.Collections;

public class Paint : MonoBehaviour
{
    public int throws = 3;
    private bool isDone = false;
    private SpriteRenderer spriteRenderer;
    private float startDestroy;
    private float destroyTime = 2.0f;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDone)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.g, 1.0f - (Time.time - startDestroy) / destroyTime);
            if (Time.time - startDestroy > destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Thrown()
    {
        throws--;
        if (throws <= 0)
        {
            startDestroy = Time.time;
            isDone = true;
        }
    }
}
