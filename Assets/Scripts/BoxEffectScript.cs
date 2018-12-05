using UnityEngine;
using System.Collections;

public class BoxEffectScript : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
	GetComponent<Rigidbody>().AddForce(Vector3.up*500f);
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(this.gameObject, 3f);
	}
	
}
