using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int totalLevels = 6; // Does not include lobby / top floor
	public int timeLimit = 100;
	public GameObject[] floorArray;

	private int totalFloors;
	private int currentFloor = 0;

	void Start () {
		totalFloors = totalLevels + 2;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	public void Promote () {
		currentFloor++;
        // stop previous level, play animaiton, start next level
        if (floorArray != null && currentFloor < floorArray.Length)
        {
            floorArray[currentFloor].GetComponentInChildren<Elevator>().isActive = true;
        }
	}

    public void Restart()
    {
        
        //if (floorArray[currentFloor] )
        {
            Transform a = floorArray[currentFloor].transform;
            string name = floorArray[currentFloor].name;
            Destroy(floorArray[currentFloor]);
            floorArray[currentFloor] = (GameObject)Instantiate(a.gameObject, a.position, Quaternion.identity);


        }
    }


    public void Restart(GameObject floorDestory, GameObject floorInstantiate)
    {
        Debug.Log("RESTARTING AGAIN");
        //if (floorArray[currentFloor] )
        {
//            Transform a = floor.transform;
            string name = floorInstantiate.name;
            Destroy(floorDestory);
            GameObject go = (GameObject)Instantiate(floorInstantiate, floorInstantiate.transform.position, Quaternion.identity);
            go.name = name;


        }
    }
}