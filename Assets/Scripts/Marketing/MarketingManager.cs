using UnityEngine;
using System.Collections;

public class MarketingManager : MonoBehaviour
{
    public bool isHolding = false;
    private GameObject playerObject;
    private GameObject paintCanvas;
    private Player playerScript;
    private GameObject red;
    private GameObject green;
    private GameObject blue;
    private Paint redPaint;
    private Paint greenPaint;
    private Paint bluePaint;
    private bool isDone = false;
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find("Player") as GameObject;
        playerScript = playerObject.GetComponent<Player>();
        //red = Instantiate(Resources.Load("Prefabs/Marketing/PaintRed"), new Vector2(transform.position.x- 2.0f, transform.position.y), Quaternion.identity) as GameObject;
        //green = Instantiate(Resources.Load("Prefabs/Marketing/PaintGreen"), new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
        //blue = Instantiate(Resources.Load("Prefabs/Marketing/PaintBlue"), new Vector2(transform.position.x + 2.0f, transform.position.y), Quaternion.identity) as GameObject;
        red = GameObject.Find("PaintRed");
        green = GameObject.Find("PaintGreen");
        blue = GameObject.Find("PaintBlue");

        redPaint = red.GetComponent<Paint>();
        greenPaint = green.GetComponent<Paint>();
        bluePaint = blue.GetComponent<Paint>();
        paintCanvas = GameObject.Find("PaintCanvas") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            playerScript.useBucket = true;
        }
        else
        {
            playerScript.useBucket = false;
        }
        if (isHolding == true)
            playerScript.useBucket = true;
        if (isHolding == false)
            playerScript.useBucket = false;
        if (redPaint.throws + greenPaint.throws + bluePaint.throws == 0 && !isDone)
        {
            SpriteRenderer rend = paintCanvas.GetComponent<SpriteRenderer>();
            Debug.Log(paintedSurface());
            Debug.Log(rend.sprite.texture.width * rend.sprite.texture.height);
            Debug.Log((paintedSurface() / (rend.sprite.texture.width * rend.sprite.texture.height)) * 100);
            int x = paintedSurface();
            int y = rend.sprite.texture.width * rend.sprite.texture.height;
            float z = x / y;
            Debug.Log(z);
            GetComponentInChildren<Elevator>().Promote();
            isDone = true;
        }
        int a = redPaint.throws + greenPaint.throws + bluePaint.throws;
        Debug.Log(a);

    }

    int paintedSurface()
    {

        SpriteRenderer rend = paintCanvas.GetComponent<SpriteRenderer>();
        Color[] a = rend.sprite.texture.GetPixels(0, 0, rend.sprite.texture.width, rend.sprite.texture.height);
        int count = 0;
        for (int x = 0; x < a.Length; x++)
            if (a[x].a != 0.0f)
                count++;
        return count;
    }
}
