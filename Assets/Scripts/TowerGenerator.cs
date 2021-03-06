﻿using UnityEngine;
using System.Collections;

public class TowerGenerator : MonoBehaviour {
	public GameObject[] levelsA, levelsB, levelsC;
	public GameObject levelLobby, levelFinal;
	public float scaleFactor = 4;
	private int levels;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		levels = gameManager.totalLevels;
		gameManager.floorArray = new GameObject[levels + 2];
		GenerateTower ();
	}

	private void GenerateTower () {
		int rand;
		GameObject go = AddFloor (levelLobby, 0);
        go.GetComponentInChildren<Elevator>().isActive = true;// Active the first floor automatically
		for (int i = 1; i <= levels; i++) {
			if (i <= levels / 3) {
				rand = Random.Range (0, levelsA.Length);
				AddFloor(levelsA[rand], i);
			} else if (i <= levels / 3 * 2) {
				rand = Random.Range (0, levelsB.Length);
				AddFloor(levelsB[rand], i);
			} else if (i <= levels) {
				rand = Random.Range (0, levelsC.Length);
				AddFloor(levelsC[rand], i);
			}
		}
		AddFloor (levelFinal, levels + 1);
	}

	private GameObject AddFloor (GameObject level, int floorNum)
	{
	    string name = level.name;
		level = (GameObject)GameObject.Instantiate (level);
		level.transform.position = new Vector3 (0, floorNum * scaleFactor, 0);
		level.transform.parent = transform;
	    level.name = name;
		gameManager.floorArray [floorNum] = level;
        return level;
	}
}
