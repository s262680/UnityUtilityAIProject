using UnityEngine;
using System.Collections;

public class shots : MonoBehaviour {
	Vector3 m;
	GameObject player;
	charScript tp;
	public GameObject effectFab;
	float timer=0f;
	
	Vector3 pos;
	public Vector3 dir;
	float angle;
	
	
	// Use this for initialization
	void Start () {
		m=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		player =GameObject.Find("p");
		tp=player.GetComponent<charScript>();
		//tp.dir.x+=120;
		//tp.dir.y+=60;
		m=tp.dir.normalized;
		
		pos = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - pos;
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0,-angle+130,0);
		GetComponent<Rigidbody>().AddForce(transform.forward*5000f);
	}
	
	// Update is called once per frame
	void Update () {
		timer-=Time.deltaTime;
		Destroy(this.gameObject,3f);
		//transform.Translate(Vector3.forward*Time.deltaTime*50f,Space.Self);
		//Debug.Log(m);
		if(timer<=0)
		{
			spawnEffects();
			timer=0.1f;
		}
	}
	
	public void spawnEffects()
	{
		GameObject enemyObject = (GameObject)Instantiate(effectFab, transform.position, Quaternion.identity);
		enemyObject.name = "effects";

	}
	
//	void OnTriggerEnter(Collider other)
//	{
//		if(other.gameObject.tag==("walls"))
//		{
//		Destroy(this.gameObject);
//		}
//	}
}
