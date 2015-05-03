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

	public void Promote () {
		currentFloor++;
        // stop previous level, play animaiton, start next level
        if (floorArray != null && currentFloor < floorArray.Length)
        {
            floorArray[currentFloor].GetComponentInChildren<Elevator>().isActive = true;
        }
	}
}