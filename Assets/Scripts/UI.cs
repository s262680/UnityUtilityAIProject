using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(0,0,300,80),"Move around by using (w,a,s,d) buttons \n Hold (Left Shift) button to boost speed \n Look around and aim by using cursor \n press (left Mouse) button to shoot");
	}
}
