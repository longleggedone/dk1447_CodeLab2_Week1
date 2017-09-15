using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public int score = 0;
	public Text scoreText;
	public Text gameOverText;

	public float speed = 1f;
	private GameObject playerColorSprite;
	private Sprite playerColor;
	public Sprite blue;
	public Sprite green;
	public Sprite red;
	public Sprite yellow;

	// Use this for initialization
	void Start () {
		gameOverText.gameObject.SetActive(false);
		playerColorSprite = transform.Find("ColorSprite").gameObject;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

		scoreText.text = ("SCORE: " + score);

	}

	void OnCollisionEnter2D (Collision2D col){
		
		if(col.gameObject.tag.Equals("Ball") == true){
			playerColor = playerColorSprite.GetComponent<SpriteRenderer>().sprite;

			Sprite colColor = col.gameObject.GetComponent<SpriteRenderer>().sprite;

			Debug.Log(colColor + " " + playerColor);

			if (colColor.name != playerColor.name) {
				
				if (colColor.name == "Blue"){
					playerColorSprite.GetComponent<SpriteRenderer>().sprite = blue;
				} else if (colColor.name == "Green"){
					playerColorSprite.GetComponent<SpriteRenderer>().sprite = green;
				} else if (colColor.name == "Red"){
					playerColorSprite.GetComponent<SpriteRenderer>().sprite = red;
				} else if (colColor.name == "Yellow"){
					playerColorSprite.GetComponent<SpriteRenderer>().sprite = yellow;
				}

				score++;

				Destroy(col.gameObject);

			} else if (colColor.name == playerColor.name){
				gameOverText.gameObject.SetActive(true);
				Destroy(this);
				//Debug.Log(colColor);
			} 
		}
	}
}
