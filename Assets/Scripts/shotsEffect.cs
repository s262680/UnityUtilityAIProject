using UnityEngine;
using System.Collections;

public class shotsEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
	Destroy(this.gameObject, 0.5f);
	}
}
