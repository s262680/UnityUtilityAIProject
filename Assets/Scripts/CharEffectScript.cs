﻿using UnityEngine;
using System.Collections;

public class CharEffectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
		Destroy(this.gameObject, 0.2f);
	}
}
