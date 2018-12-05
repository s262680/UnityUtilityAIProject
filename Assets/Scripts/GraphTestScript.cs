using UnityEngine;
using System.Collections;

public class GraphTestScript : MonoBehaviour {

	GameObject line;


	// Use this for initialization
	void Start () {
		line = new GameObject ();
		line.AddComponent<LineRenderer>();

	}

	// Update is called once per frame
	void Update () {
		//DrawLinearCurve (0,100);
		DrawQuadraticCurve(0,100,0.5f);
		//DrawPiecewiseLinearCurve(0,100);
	}

	void DrawLinearCurve(float input, int max)
	{
		LineRenderer lr = line.GetComponent<LineRenderer>();
		line.transform.position = new Vector3(0,0,0);
		lr.SetWidth(1f, 1f);
		lr.SetVertexCount (max);

		for(int i=0; input<max;i++)
		{
			
			float utility = input / max;
			lr.SetPosition (i, new Vector3(input,utility*max,0));
			input++;
			//Debug.Log (desire);
		}

	}

	void DrawQuadraticCurve(float input, int max, float pow)
	{
		LineRenderer lr = line.GetComponent<LineRenderer>();
		line.transform.position = new Vector3(0,0,0);
		lr.SetWidth(1f, 1f);
		lr.SetVertexCount (max);

		for(int i=0; input<max;i++)
		{

			float utility = Mathf.Pow(input / max, pow);
			lr.SetPosition (i, new Vector3(input,utility*max,0));
			input++;
		}

	}

	void DrawPiecewiseLinearCurve(float input, int max)
	{
		LineRenderer lr = line.GetComponent<LineRenderer>();
		line.transform.position = new Vector3(0,0,0);
		lr.SetWidth(1f, 1f);
		lr.SetVertexCount (max);
		float utility=0;

		for(int i=0; input<max;i++)
		{
			if (input <= max / 3) 
			{
				utility += 0.01f;
			} 
			else if (input <= max / 1.5f) 
			{
				utility -= 0.01f;
			} 
			else 
			{
				utility += 0.02f;
			}

			lr.SetPosition (i, new Vector3(input,utility*max,0));
			input++;
		}

	}

//	void DrawPiecewiseLinearCurve2(float[] inputs, float[] utiltiy)
//	{
//		LineRenderer lr = line.GetComponent<LineRenderer>();
//		line.transform.position = new Vector3(0,0,0);
//		lr.SetWidth(0.1f, 0.1f);
//		lr.SetVertexCount (100);
//		float utility=0;
//
//		for(int i=0; i<inputs.Length;i++)
//		{
//			xInputs[i]
//
//			lr.SetPosition (i, new Vector3(0,utility*max,0));
//
//		}
//
//	}

}
