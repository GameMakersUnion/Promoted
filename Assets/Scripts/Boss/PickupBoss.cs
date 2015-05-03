using UnityEngine;
using System.Collections;

public class PickupBoss : MonoBehaviour {
    private HoldableBoss parentHoldableBoss;
    private BossManager bossManager;
    // Use this for initialization
    void Start () {
        parentHoldableBoss = GetComponentInParent<HoldableBoss>();
        bossManager = GetComponentInParent<BossManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (bossManager.isHolding == false)
                {
                    bossManager.isHolding = true;
                    gameObject.layer = 9;
                    parentHoldableBoss.PickUp();
                }
            }
        }
    }
}
