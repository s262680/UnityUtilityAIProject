using UnityEngine;
using System.Collections;

public class charScript : MonoBehaviour {


	float movementRate=10f;
	Vector3 pos;
	public Vector3 dir;
	float angle;
	public GameObject effectFab;
	float timer=0.01f;
	public AudioSource engine;
	GameObject enemy;
	enemyAIScript es;
	
	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("enemy");
		es = enemy.GetComponent<enemyAIScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("w"))
		{
			transform.Translate(new Vector3(1,0,1)*Time.deltaTime*movementRate, Space.World);
			//Camera.main.transform.Translate(Vector3.up*Time.deltaTime*movementRate);
		}
		if(Input.GetKey("s"))
		{
			transform.Translate(new Vector3(-1,0,-1)*Time.deltaTime*movementRate, Space.World);
		}
		if(Input.GetKey("a"))
		{
			transform.Translate(new Vector3(-1,0,1)*Time.deltaTime*movementRate, Space.World);
		}
		if(Input.GetKey("d"))
		{
			transform.Translate(new Vector3(1,0,-1)*Time.deltaTime*movementRate, Space.World);
		}
		
//		if(Input.GetKeyDown("space"))
//		{
//		
//			rigidbody.AddForce(transform.up*700000f);
//		}
		if(Input.GetKey("left shift"))
		{
			engine.enabled=true;
			GetComponent<Rigidbody>().AddForce(transform.forward*50000f);
			timer-=Time.deltaTime;
			if(timer<=0)
			{
				spawnEffects();
				timer=0.01f;
			}
		}
		if(Input.GetKeyUp("left shift"))
		{
			engine.enabled=false;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
			
		
		}
		
		pos = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - pos;
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0,-angle+130,0);
		//Debug.Log(angle);
	}
	
	public void spawnEffects()
	{
		GameObject enemyObject = (GameObject)Instantiate(effectFab, transform.position+new Vector3(Random.Range(-1.5f,1.5f),-4.5f,Random.Range(-1.5f,1.5f)), Quaternion.identity);
		enemyObject.name = "effects";
	}

//	void OnTriggerEnter(Collider other)
//	{
//		if (other.gameObject.name == "enemy") 
//		{
//			es.foundPlayer = true;
//
//		}
//	}
//
//	void OnTriggerExit(Collider other)
//	{
//		if (other.gameObject.name == "enemy") 
//		{
//			es.foundPlayer = false;
//
//		}
//	}
}
