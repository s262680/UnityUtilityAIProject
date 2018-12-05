using UnityEngine;
using System.Collections;

public class InvisItemScript : MonoBehaviour {

	
	float rotateSpeed=50f;
	// Use this for initialization
	void Start () {
		transform.eulerAngles=new Vector3(90,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward*Time.deltaTime*rotateSpeed);
		Destroy(this.gameObject,0.1f);
	}
	
}