using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PCManager : MonoBehaviour
{
    [HideInInspector]
    public List<PC> PCs = new List<PC>(); //populated from each child PC.
    //private const int goalReboots = 15;
    private const int goalLiving = 3;
    public int reboots = 0;
    private float time = 20f;
    private Text textTimer;
    private Text textPCs;
    private Text textReboots;
    public bool hasWon = false;
    public bool hasLost = false;
    public bool playerInside = false; 

    // Use this for initialization
    void Start ()
	{
        //rand time
        //Random.seed = 42;

//        textTimer = GameObject.Find("Canvas/Timer/Outline").GetComponent<Text>();

//        textPCs = GameObject.Find("Canvas/PCs/Outline").GetComponent<Text>();


	}

    // Update is called once per frame
    void Update ()
    {

        bool okReboot = this.GetComponent<PCManager>().playerInside;

        if (!okReboot)
        {
            return;
        }


        if (time > 0)
        {
            time -= Time.deltaTime;
        }

//        textTimer.text = Mathf.CeilToInt(time).ToString();
//
//        textPCs.text = Living().ToString();

        if(!hasLost && PCs.Count > 0)
            if (CheckFailCondition())
            {
                hasLost = true;
            }
            else
            {
                CheckWinCondition();
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

    bool CheckWinCondition()
    {
        if (time <= 0 && PCs.Count >= goalLiving)
        {
            hasWon = true;
            GetComponentInChildren<Elevator>().Promote();
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckFailCondition()
    {
        Debug.Log(Living());

        if (time <= 0 && Living() < goalLiving || Living() <= 0)
        {
            Debug.Log("FAILED");
            GetComponentInChildren<Elevator>().Demote();
            GameObject killme = this.gameObject;
            GameObject birthme = Resources.Load<GameObject>("Prefabs/Levels/Level_B_02");
            GameObject.Find("GameManager").GetComponent<GameManager>().Restart(killme, birthme);
            //restart
            return true;
        }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("INSIDE");
            playerInside = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }


}
