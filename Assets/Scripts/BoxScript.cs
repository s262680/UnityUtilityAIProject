using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
	public GameObject effectFab;
	public GameObject itemFab;
	public GameObject InvisitemFab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag==("shots"))
		{
			spawnInvisItem();
			spawnItem();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			spawnEffects();
			Destroy(this.gameObject);		
		}
	}
	public void spawnEffects()
	{
		GameObject enemyObject = (GameObject)Instantiate(effectFab, transform.position+new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f),Random.Range(-3f,3f)), Quaternion.identity);
		enemyObject.name = "effects";
	}
	public void spawnItem()
	{
		GameObject itemObject = (GameObject)Instantiate(itemFab, transform.position, Quaternion.identity);
		itemObject.name = "item";
	}
	public void spawnInvisItem()
	{
		GameObject InvisitemObject = (GameObject)Instantiate(InvisitemFab, transform.position, Quaternion.identity);
		InvisitemObject.name = "Invisitem";
	}
}
