using UnityEngine;
using System.Collections;


public class enemyAIScript : MonoBehaviour {

	public GameObject shotsFab;
	public AudioClip hit;
	GameObject player;
	GameObject healthpack;
	GameObject ammopack;
	Vector3 p2eDir;
	Vector3 e2pDir;
	Vector3 e2hDir;
	Vector3 e2aDir;
	bool runAway=false;
	bool bkToNormal=false;
	bool stopLoop=false;
	public bool foundPlayer=false;
	Vector3 screenPos;
	float shotTimer=0;

	const float MaxEnemyHealth=100;
	const float MaxEnemyAmmo=30;
	float enemyHealth=100;
	float enemyAmmo=30;

	float engageUtility=0;
	float healthUtility=0;
	float ammoUtility=0;
	float fleeUtility=0;
	float idleUtility=0;

	float[] utilityArray;

	int utilityResult=-1;

	bool keepGoing=false;




	void Start () {
		player = GameObject.Find ("p");
		healthpack = GameObject.Find ("healthpack");
		ammopack = GameObject.Find ("ammopack");
	
		utilityArray=new float[5];
	}



	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody>().velocity = Vector3.zero;

		if (shotTimer > 0) 
		{
			shotTimer -= Time.deltaTime;
		}

		screenPos = Camera.main.WorldToScreenPoint (transform.position);

		//Debug.Log ((player.transform.position - this.transform.position).sqrMagnitude);
		if((player.transform.position - this.transform.position).sqrMagnitude <5000f)

		{
			foundPlayer = true;
		} 
		else 
		{
			foundPlayer = false;
		}
			

		//Utility************************************************************************************************************************************************************

		BeginUtility ();

		//Decision Tree**************************************************************************************************************************************************************

		//BeginDecisionTree ();


		if (enemyHealth <= 0) 
		{
			Destroy (this.gameObject);
		}




















		//Debug.Log (linearCurve (enemyHealth + enemyAmmo, MaxEnemyAmmo + MaxEnemyHealth));

		//Debug.Log (utilityArray [0]);
		//Debug.Log (utilityArray [1]);



	
		//Debug.Log (engageUtility);




//			switch (GetUtilityResult ()) 
//			{
//			case 0:
//				engage ();			
//				break;
//			case 1:
//				getHealthPack ();
//				break;
//			case 2:
//				getAmmoPack ();
//				break;
//			case 3:
//				Run ();
//				break;
//			case 4:
//				//Idle;
//				break;
//			}





//		if (GetUtilityResult()==0) 
//			{
//				if (foundPlayer) 
//				{
//					//Debug.Log ("engage");
//					engage ();
//				} 
//				else 
//				{
//					//Debug.Log ("normal");
//				}
//			}
//							
//		else if (GetUtilityResult()==1)
//			{
//				//Debug.Log ("healthpack");
//				if(GameObject.Find("healthpack"))
//				{
//					getHealthPack ();
//				}
//	
//			}
//
//		else if (GetUtilityResult()==2) 
//			{
//				//Debug.Log ("ammopack");
//				if (GameObject.Find ("ammopack")) 
//				{
//					getAmmoPack ();
//				} 
//				else 
//				{
//					Run ();
//				}
//			}



//		if (enemyHealth > MaxEnemyHealth/2)
//		{
//			if (enemyAmmo > MaxEnemyAmmo/2) 
//			{
//				if (foundPlayer) {
//					engage ();
//				} 
//				else 
//				{
//					//idle;
//				}
//			} 
//			else 
//			{
//				if (GameObject.Find ("ammopack")) 
//					{
//						getAmmoPack ();
//					} 
//					else 
//					{
//						Run ();
//					}
//			}
//		} 
//		else 
//		{
//			if(GameObject.Find("healthpack"))
//			{
//				getHealthPack ();
//			}
//			else
//			{
//				Run ();
//			}
//		}
//


//			if (linearCurve (enemyHealth, MaxEnemyHealth) > linearCurve (enemyAmmo, MaxEnemyAmmo)) 
//			{
//				getHealthPack ();
//			}
//
//			if (linearCurve (enemyAmmo, MaxEnemyAmmo) > linearCurve (enemyHealth, MaxEnemyHealth)) 
//			{
//				getAmmoPack ();
//			}



//			if (engageUtility > healthUtility || engageUtility > ammoUtility) 
//			{
//				Debug.Log ("engage");
//				engage ();
//			}
//				
//			if (healthUtility > engageUtility && healthUtility>ammoUtility)
//			{
//				Debug.Log ("healthpack");
//
//				getHealthPack ();
//			}
//
//			if (ammoUtility > engageUtility && ammoUtility>healthUtility) 
//			{
//				Debug.Log ("ammopack");
//
//				getAmmoPack ();
//			}

		

		//finished action before start next action
		//timer for the action
		//dynamic utitlty, + or - unitlity by time
			

//		if (runAway) 
//		{
//			
//			p2eDir = transform.position - player.transform.position;
//			p2eDir.Normalize ();
//			gameObject.transform.Translate (new Vector3 (p2eDir.x, 0, p2eDir.z) * 1f);
//			if(stopLoop)
//			{
//				StartCoroutine (UnderAttack ());
//				stopLoop = false;
//			}
//		}
			


	}



	void OnTriggerEnter(Collider other)
			{
				if(other.gameObject.tag==("shots"))
				{
			
				GetComponent<AudioSource>().PlayOneShot(hit);
				enemyHealth -= 10;
				//runAway = true;
				//stopLoop = true;
				//GetComponent<Renderer>().enabled=false;			
				}
				
		if(other.gameObject.name==("healthpack"))
				{
				enemyHealth=MaxEnemyHealth;
				}
		if(other.gameObject.name==("ammopack"))
				{
					enemyAmmo=MaxEnemyAmmo;
				}

			}



	IEnumerator UnderAttack()
	{
		yield return new WaitForSeconds (5);
		runAway = false;
		StartCoroutine (BackToNormal ());
	

	}

	IEnumerator BackToNormal()
	{
		bkToNormal = true;
		yield return new WaitForSeconds (3);
		bkToNormal = false;

	}

	public void spawnShots()
	{
		GameObject shot = (GameObject)Instantiate(shotsFab, transform.localPosition+new Vector3(0,0,0), Quaternion.identity);
		shot.name = "shots";

	}

	public float linearCurve(float input, float max)
	{
		float utility = (input / max);
		return utility;
	}

	public float QuadraticCurve(float input, float max, float pow)
	{
		float utility = 1-Mathf.Pow(input / max, pow);
		return utility;
	}

	public float PiecewiseLinearCurve(float input, float max)
	{
		float utility=0;


			if (input >= max / 3) 
			{
				utility = 0.0f;
			} 
			else 
			{
				utility = 0.6f;
			}
				
	
		return utility;
	}

	public void getHealthPack()
	{
		e2hDir = healthpack.transform.position-transform.position;
		e2hDir.Normalize();
		gameObject.transform.Translate (new Vector3 (e2hDir.x, 0, e2hDir.z) * 1f);

	}

	public void getAmmoPack()
	{
		e2aDir = ammopack.transform.position-transform.position;
		e2aDir.Normalize();
		gameObject.transform.Translate (new Vector3 (e2aDir.x, 0, e2aDir.z) * 1f);

	}

	public void engage()
	{
		e2pDir = player.transform.position - transform.position;
		e2pDir.Normalize ();
		gameObject.transform.Translate (new Vector3 (e2pDir.x, 0, e2pDir.z) * 0.5f);
		if (shotTimer <=0&&enemyAmmo>0) 
		{
			spawnShots ();
			enemyAmmo -= 1;
			shotTimer = 1;
		}
	}

	public void Run()
	{
		p2eDir = transform.position - player.transform.position;
		p2eDir.Normalize ();
		gameObject.transform.Translate (new Vector3 (p2eDir.x, 0, p2eDir.z) * 1f);
		if(stopLoop)
		{
			StartCoroutine (UnderAttack ());
			stopLoop = false;
		}
	}

	public int GetUtilityResult()
	{
		
		engageUtility = linearCurve (enemyHealth + enemyAmmo, MaxEnemyAmmo + MaxEnemyHealth);
		if (!foundPlayer) 
		{
			engageUtility = 0.0f;
		}
		healthUtility = QuadraticCurve (enemyHealth, MaxEnemyHealth, 0.7f);
		if(!GameObject.Find("healthpack"))
		{
			healthUtility = 0.0f;
		}
		ammoUtility = QuadraticCurve (enemyAmmo, MaxEnemyAmmo, 0.7f);
		if (!GameObject.Find ("ammopack")) 
		{
			ammoUtility = 0.0f;
		}
		fleeUtility = PiecewiseLinearCurve (enemyHealth+ enemyAmmo ,MaxEnemyAmmo +MaxEnemyHealth);
		idleUtility = 0.2f;
		//Debug.Log (fleeUtility);
		//Debug.Log (engageUtility);
		utilityArray[0]=engageUtility;
		utilityArray[1]=healthUtility;
		utilityArray[2]=ammoUtility;
		utilityArray[3]=fleeUtility;
		utilityArray[4]=idleUtility;

		float max = utilityArray [0];

		for (int i = 0; i < utilityArray.Length; i++)
		{
			if (utilityArray [i] >= max) 
			{
				
				max = utilityArray [i];
				utilityResult = i;
			}
		}

		return utilityResult;
	}


	public void BeginUtility()
	{
		switch (GetUtilityResult ()) 
		{
		case 0:
			engage ();			
			break;
		case 1:
			//keepGoing = true;
			getHealthPack ();
			break;
		case 2:
			getAmmoPack ();
			break;
		case 3:
			Run ();
			break;
		case 4:
			//Idle;
			break;
		}

//		if (keepGoing) {
//			getHealthPack ();
//		} else if (enemyHealth == 100) {
//			keepGoing = false;
//		}

	}

	public void BeginDecisionTree()
	{
		if (enemyHealth > MaxEnemyHealth/2)
		{
			if (enemyAmmo > MaxEnemyAmmo/2) 
			{
				if (foundPlayer) {
					engage ();
				} 
				else 
				{
					//idle;
				}
			} 
			else 
			{
				if (GameObject.Find ("ammopack")) 
				{
					getAmmoPack ();
				} 
				else 
				{
					Run ();
				}
			}
		} 
		else 
		{
			if(GameObject.Find("healthpack"))
			{
				getHealthPack ();
			}
			else
			{
				Run ();
			}
		}

	}



	void OnGUI()
	{
		GUI.Box (new Rect (screenPos.x-80, Screen.height - screenPos.y-100, 200, 25), "Health: "+enemyHealth+" Ammo: "+enemyAmmo);
		if (runAway) 
		{
			GUI.Box (new Rect (screenPos.x-80, Screen.height - screenPos.y-50, 200, 50), "I need to run!!");
		}
		if (bkToNormal&&!runAway) 
		{
			GUI.Box (new Rect (screenPos.x-80, Screen.height - screenPos.y-50, 200, 50), "Cancel alarm");

		}
		if (foundPlayer) 
		{
			GUI.Box (new Rect (screenPos.x-80, Screen.height - screenPos.y-50, 200, 50), "ENEMY SIGHTED");
		}
	}
}
