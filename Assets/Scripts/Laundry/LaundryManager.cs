using UnityEngine;
using System.Collections;

public class LaundryManager : MonoBehaviour {
    private int moneyCleaned = 0;
    private bool stopCounting = false;

	// Use this for initialization
	void Start () {
	
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
        Debug.Log(moneyCleaned);
        if(!stopCounting)
            moneyCleaned++;
    }
}
