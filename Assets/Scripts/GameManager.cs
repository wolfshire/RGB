using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject Ball;
	public GameObject Basketball;
	public Text ScoreText;

	private GameObject redSlot;
	private GameObject greenSlot;
	private GameObject blueSlot;

	private GameObject correctSphere;

	private Vector3 correctColor;

	private int score = 0;

	// Use this for initialization
	void Start () {
		for (int i = 10; i < 255; i++)
		{
			SpawnBall(new Color(i / 255f, 0, 0));
		}
		for (int i = 10; i < 255; i++)
		{
			SpawnBall(new Color(0, i / 255f, 0));
		}
		for (int i = 10; i < 255; i++)
		{
			SpawnBall(new Color(0, 0, i / 255f));
		}

		Instantiate(Basketball, new Vector3(Random.Range(-20f, 20f), Random.Range(10f, 50f), Random.Range(-20f, 20f)), Quaternion.identity);

		SelectColors();

		redSlot = GameObject.Find("RedSlot");
		greenSlot = GameObject.Find("GreenSlot");
		blueSlot = GameObject.Find("BlueSlot");

		redSlot.GetComponent<Slot>().SetCorrectBallColor(new Vector3(correctColor.x, 0, 0));
		greenSlot.GetComponent<Slot>().SetCorrectBallColor(new Vector3(0, correctColor.y, 0));
		blueSlot.GetComponent<Slot>().SetCorrectBallColor(new Vector3(0, 0, correctColor.z));

		ScoreText.text = "Score: " + score;

		correctSphere = GameObject.Find("CorrectSphere");
		correctSphere.GetComponent<Renderer>().material.color = new Color (correctColor.x / 255, correctColor.y / 255, correctColor.z / 255);

	}
	
	// Update is called once per frame
	void Update () {}

	private void SelectColors()
	{
		Color random = new Color(Random.Range(10, 255) / 255f, Random.Range(10, 255) / 255f, Random.Range(10, 255) / 255f);
		correctColor = new Vector3(random.r * 255, random.g * 255, random.b * 255);
		Debug.Log(correctColor);
	}

	private void SpawnBall(Color color)
	{
		GameObject newBall = Instantiate(Ball, transform.position + new Vector3(Random.Range(-20f, 20f), Random.Range(10f, 50f), Random.Range(-20f, 20f)), Quaternion.identity);
		newBall.GetComponent<Renderer>().material.color = color;
		newBall.GetComponent<Ball>().BallColor = new Vector3(color.r * 255, color.g * 255, color.b * 255);
		newBall.name = "(" + color.r * 255 + "," + color.g * 255 + "," + color.b * 255 + ")";
	}

	public void IncreaseScore()
	{
		score++;
		ScoreText.text = "Score: " + score;
	}
}
