﻿using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    private Holdable parentHoldable;
    private MarketingManager parentMarketingManager;

    // Use this for initialization
    void Start()
    {
        parentHoldable = GetComponentInParent<Holdable>();
        parentMarketingManager = GetComponentInParent<MarketingManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (parentMarketingManager.isHolding == false)
                {
                    //
                    //
                    if (parentHoldable.PickUp())
                    {
                        parentMarketingManager.isHolding = true;
                        gameObject.layer = 9;
                    }
                }
            }
        }
    }
}
