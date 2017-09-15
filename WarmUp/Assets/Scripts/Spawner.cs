using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject ball;
	public float timeToStart = 1f;
	public float timeBetween = 1f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpriteTime",timeToStart, timeBetween);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpriteTime(){
		int nextNum = GetComponent<NumberGenerator>().Next();

		MakeSprite(nextNum);
	}

	void MakeSprite(int num){
		GameObject newBall = Instantiate (ball, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
		newBall.GetComponent<SpriteRenderer>().sprite = sprites[num];
	}
}
