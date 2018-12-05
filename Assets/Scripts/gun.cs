using UnityEngine;
using System.Collections;

public class gun : MonoBehaviour {
	
	
	public GameObject shotsFab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0))
		{
		spawnShots();
		}
	
	
	}
	
	
	
	public void spawnShots()
	{
	GameObject enemyObject = (GameObject)Instantiate(shotsFab, transform.position, Quaternion.identity);
	enemyObject.name = "shots";
	}
}
