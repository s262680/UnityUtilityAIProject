using UnityEngine;
using System.Collections;

public class itemScript : MonoBehaviour {

	public AudioClip coin;
	bool trigger=false;
	float rotateSpeed=50f;
	// Use this for initialization
	void Start () {
	transform.eulerAngles=new Vector3(90,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	transform.Rotate(Vector3.forward*Time.deltaTime*rotateSpeed);
	if(trigger)
	{
	transform.Translate(new Vector3(0,0,-1)*Time.deltaTime*50f);
	rotateSpeed=500f;
	}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name==("p")||other.gameObject.name==("enemy"))
		{
			GetComponent<AudioSource>().PlayOneShot(coin,1f);
			trigger=true;
			Destroy(this.gameObject,1f);		
		}
	}
}
