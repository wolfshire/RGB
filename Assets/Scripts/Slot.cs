using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public Vector3 correctBallColor;

	private GameManager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCorrectBallColor(Vector3 colorVec)
	{
		correctBallColor = colorVec;
		name = "" + correctBallColor;
	}

	void OnCollisionEnter(Collision collision)
	{
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Ball")
		{
			if (collider.gameObject.GetComponent<Ball>().BallColor == correctBallColor)
			{
				Debug.Log("Yes");
				//GameManager gm = FindObjectOfType<GameManager>();
			}
			else
			{
				Debug.Log("No");
			}
		}
	}
}
