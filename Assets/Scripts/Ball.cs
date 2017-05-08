using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 BallColor;


	private Vector3 prevPosition;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		velocity = transform.position - prevPosition;
		prevPosition = transform.position;

		if (transform.position.y < -10)
		{
			Reset();
		}
	}

	public void Launch()
	{
		if(GetComponent<Rigidbody>() != null)
		{
			GetComponent<Rigidbody>().AddForce(velocity * 1000);
		}
	}

	private void Reset()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		transform.position = new Vector3(0, 30, 0);
	}
}
