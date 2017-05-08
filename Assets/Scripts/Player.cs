using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private GameObject cam;
	private int speed = 10;
	private int jumpPower = 250;
	private bool canJump = false;

	private Ray ray;
	private RaycastHit hit;

	private GameObject holdLocation;

	private GameObject held;

	private float xRot = 0;

	private Rigidbody rb;

	// Use this for initialization
	void Start()
	{
		cam = GameObject.Find("Main Camera");
		holdLocation = GameObject.Find("HoldLocation");
		rb = GetComponent<Rigidbody>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}

	// Update is called once per frame
	void Update()
	{
		KeyControls();
		MouseControls();
		RaycastControls();
		BalancePlayer();

		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Break();
		}
	}

	private void KeyControls()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			canJump = false;
			rb.AddForce(Vector3.up * jumpPower);
		}
	}

	private void MouseControls()
	{
		if (Input.GetAxis("Mouse X") > 0)
		{
			transform.Rotate(Vector3.up * speed * Input.GetAxis("Mouse X"));
		}
		if (Input.GetAxis("Mouse X") < 0)
		{
			transform.Rotate(Vector3.up * speed * Input.GetAxis("Mouse X"));
		}
		if (Input.GetAxis("Mouse Y") > 0 && xRot < 6)
		{
			cam.transform.Rotate(Vector3.left * speed * Input.GetAxis("Mouse Y"));
			xRot += Input.GetAxis("Mouse Y");
		}
		if (Input.GetAxis("Mouse Y") < 0 && xRot > -6)
		{
			cam.transform.Rotate(Vector3.left * speed * Input.GetAxis("Mouse Y"));
			xRot += Input.GetAxis("Mouse Y");
		}
	}

	private void RaycastControls()
	{
		if (Input.GetMouseButton(0))
		{
			if (held == null)
			{
				if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 3f))
				{
					GameObject target = hit.transform.gameObject;
					if (target.tag == "Ball" || target.tag == "Basketball")
					{
						held = target;
						Destroy(held.GetComponent<Rigidbody>());
						held.transform.SetParent(holdLocation.transform);
						held.transform.position = holdLocation.transform.position;
						held.tag = "Ball";
					}
				}
			}
		}

		else
		{
			UnequipHeld();
		}
	}

	public void UnequipHeld()
	{
		if (held != null)
		{
			held.transform.SetParent(null);
			held.AddComponent<Rigidbody>();
			held.GetComponent<Ball>().Launch();
			held = null;
		}
	}

	private void BalancePlayer()
	{
		if (transform.rotation.x != 0 || transform.rotation.z != 0)
		{
			transform.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Floor")
		{
			canJump = true;
		}
	}
}
