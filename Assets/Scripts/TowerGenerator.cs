using UnityEngine;
using System.Collections;

public class TowerGenerator : MonoBehaviour {
	public int floors = 12;
	public GameObject[] levelsA, levelsB, levelsC;
	public GameObject levelLobby, levelFinal;
	float scaleFactor = 4;

	// Use this for initialization
	void Start () {
		floors = floors - (floors % 3);
		GenerateTower ();
	}

	void GenerateTower () {
		GameObject level;
		int rand;
		AddFloor (levelLobby, 0);
		for (int i = 1; i <= floors; i++) {
			if (i <= floors / 3) {
				rand = Random.Range (0, levelsA.Length);
				AddFloor(levelsA[rand], i);
			} else if (i <= floors / 3 * 2) {
				rand = Random.Range (0, levelsB.Length);
				AddFloor(levelsB[rand], i);
			} else if (i <= floors) {
				rand = Random.Range (0, levelsC.Length);
				AddFloor(levelsC[rand], i);
			}
		}
		AddFloor (levelFinal, floors + 1);
	}

	void AddFloor (GameObject level, int height) {
		level = (GameObject)GameObject.Instantiate (level);
		level.transform.position = new Vector3 (0,height * scaleFactor,0);
		level.transform.parent = transform;
	}
}
