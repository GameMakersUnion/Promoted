using UnityEngine;
using System.Collections;

public class LaundryManager : MonoBehaviour {
    private int moneyCleaned = 0;
    private bool stopCounting = false;
    public int goal = 10;

	// Use this for initialization
	void Start () {
        SoundManager.Play(SoundManager.Sounds.WashingMachine);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Completed()
    {

    }

    public int MoneyCount()
    {
        
        return moneyCleaned;
    }
    public void MoneyCleaned()
    {
        
        if(!stopCounting)
            moneyCleaned++;
        //Debug.Log(moneyCleaned);
    }
}
