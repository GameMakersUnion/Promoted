﻿using UnityEngine;
using System.Collections;

public class PC : PCManager
{

    private BoxCollider2D box;
    private SpriteRenderer renderer;
    private Animator animator;
    private bool nearby = false;
    private Player player;

    private const float TIME_TO_BOOT = 3f;
    private const float TIME_TO_FLAMES = 3f;
    private float timeToCrashStart; 
    private float timeToCrash; //assigned on start
    private float health = 5f;  


    private float timeCrashed = 0;
    private float timeBooting = 0;

    private enum State { Booting, Stable, Crashed, Flaming, Burnt }

    private State state = State.Stable;
    

    // Use this for initialization
    void Start () {
        box = gameObject.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("stable", true);
        player =  GameObject.FindWithTag("Player").GetComponent<Player>();
        timeToCrashStart = Random.Range(TIME_TO_BOOT + 1f, TIME_TO_BOOT + 1f);
        timeToCrash = timeToCrashStart;
        PCs.Add(this);
    }

    private void Update()
    {

        Debug.Log(this.name + ": " + state + ", " + timeToCrash +","+ timeBooting + ", " + timeCrashed + ", " + health);
        //exit early
        if (state == State.Burnt)
        {
            return;
        }

        //rebooting
        if (state == State.Booting && timeBooting < TIME_TO_BOOT)
        {
            timeBooting += Time.deltaTime;
        }

        //go stable
        else if (state == State.Booting && timeBooting >= TIME_TO_BOOT)
        {
            state = State.Stable;
            animator.SetBool("booting", false);
            animator.SetBool("stable", true);
            timeBooting = 0;
            timeToCrash = timeToCrashStart;
        }


        //unstable 'puter
        if (state == State.Stable && timeToCrash > 0)
        {
            timeToCrash -= Time.deltaTime;
        }

        //go blue screen
        if (state == State.Stable && timeToCrash <= 0)
        {
            state = State.Crashed;
            animator.SetBool("stable", false);
            animator.SetBool("crashed", true);
            Debug.Log("CRASHED");
        }

        //VERY unstable 'puter
        if (state == State.Crashed)
        {
            timeCrashed += Time.deltaTime;
        }

        //go on fire
        if (state == State.Crashed && timeCrashed > TIME_TO_FLAMES)
        {
            state = State.Flaming;
            animator.SetBool("crashed", false);
            animator.SetBool("flaming", true);
        }

        //hurt 'puter
        if (state == State.Flaming)
        {
            health -= Time.deltaTime;

        }

        //go burnt
        if (state == State.Flaming && health <= 0)
        {
            state = State.Burnt;
//            animator.StopPlayback();
            animator.SetBool("flaming", false);
            animator.SetBool("crashed", true); //same thing
//            animator.StartPlayback();
            renderer.color = new Color(.2f, .2f, .2f);
        }

    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        //do main logic here
        if (nearby && player.activating && (state == State.Crashed || state == State.Flaming))
        {
            state = State.Booting;
            timeBooting = 0;
            timeCrashed = 0;
            timeToCrash = timeToCrashStart;

            animator.SetBool("crashed", false);
            animator.SetBool("flaming", false);
            animator.SetBool("booting", true);

        }


    }

    void Crashing()
    {
        
    }

    void Rebooting()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nearby = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nearby = false;
        }
    }
}
