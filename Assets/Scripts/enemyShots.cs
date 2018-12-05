using UnityEngine;
using System.Collections;

public class enemyShots : MonoBehaviour {

	GameObject player;
	GameObject enemy;
	Vector3 dir;
	// Use this for initialization
	void Start () {


		player = GameObject.Find ("p");
		enemy = GameObject.Find ("enemy");
		dir=player.transform.position - enemy.transform.position;
		dir.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (dir.x, 0, dir.z) * Time.deltaTime*50f);
		Destroy (this.gameObject, 2f);
	}
}
