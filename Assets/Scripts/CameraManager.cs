using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	GameManager gameManager;
	TowerGenerator towerGenerator;
	// Use this for initialization
	void Start () {
		towerGenerator = GameObject.Find ("Tower").GetComponent<TowerGenerator> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		transform.position = new Vector3 (0, (gameManager.floorArray.Length-1) * towerGenerator.scaleFactor, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	float timePassed = 0;
	void FixedUpdate () {
		timePassed += Time.deltaTime;
		float maxDist = timePassed * timePassed;
		transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, maxDist);
	}
}
