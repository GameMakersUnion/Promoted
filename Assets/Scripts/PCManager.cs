using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PCManager : MonoBehaviour
{
    public List<PC> PCs = new List<PC>(); //populated from each child PC.
    private const int goalReboots = 15;
    public int reboots = 0;
    private float time = 60f;
    private Text textTimer;
    private Text textPCs;
    private Text textReboots;

    // Use this for initialization
    void Start ()
	{
        //rand time
        //Random.seed = 42;

        textTimer = GameObject.Find("Canvas/Timer/Outline").GetComponent<Text>();

        textPCs = GameObject.Find("Canvas/PCs/Outline").GetComponent<Text>();

        textReboots = GameObject.Find("Canvas/Reboots/Outline").GetComponent<Text>();


	}

    // Update is called once per frame
    void Update ()
    {
        time -= Time.deltaTime;
        textTimer.text = Mathf.CeilToInt(time).ToString();

        textPCs.text = Living().ToString();

        textReboots.text = reboots + "-" + goalReboots;

        if (PCs.Count <= 5)
        {
            textPCs.color = Color.green;
        }

        else if (PCs.Count <= 3)
        {
            textPCs.color = Color.red;
        }

        else if (PCs.Count <= 1)
        {
            textPCs.color = Color.gray;
        }

    }

    float Living()
    {
        int living = 0;
        foreach (PC pc in PCs)
        {
            if (pc.health > 0)
            {
                living ++;
            }
        }
        return living;
    }

}
