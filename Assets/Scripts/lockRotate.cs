using UnityEngine;
using System.Collections;

public class lockRotate : MonoBehaviour {

	Vector3 pPos;
	Vector3 cPos;
	GameObject player;
	// Use this for initialization
	void Start () {
	player=GameObject.Find("p");
	}
	
	// Update is called once per frame
	void Update () {
		pPos=player.transform.position;
		
		cPos.x=pPos.x-50;
		cPos.y=pPos.y+120;
		cPos.z=pPos.z-50;
		transform.position=cPos;
	}
	
	
}
