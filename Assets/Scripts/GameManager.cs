using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int totalLevels = 12; // Does not include lobby / top floor
	public int timeLimit = 100;
	public GameObject[] floorArray;

	private int totalFloors;
	private int currentFloor = 0;

	void Start () {
		totalLevels = totalLevels - (totalLevels % 3);
		totalFloors = totalLevels + 2;
		floorArray = new GameObject[totalFloors];
	}

	public void Promote () {
		currentFloor++;
		// stop previous level, play animaiton, start next level
	}
}