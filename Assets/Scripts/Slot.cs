using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public Vector3 correctBallColor;

	private GameManager gm;

	private GameObject held;

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
				held = collider.gameObject;
				Destroy(held.GetComponent<Ball>());
				Destroy(held.GetComponent<SphereCollider>());
				
				Player p = FindObjectOfType<Player>();
				p.UnequipHeld();

				Destroy(held.GetComponent<Rigidbody>());
				held.transform.position = transform.position;

				GameManager gm = FindObjectOfType<GameManager>();
				gm.IncreaseScore();
			}
			else
			{

			}
		}
	}
}
