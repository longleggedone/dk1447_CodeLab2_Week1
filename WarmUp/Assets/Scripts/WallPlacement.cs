using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacement : MonoBehaviour {

	public float colDepth = 4f;
	public float zPos = 0f;

	public GameObject topCol;
	public GameObject bottomCol;
	public GameObject leftCol;
	public GameObject rightCol;

	private Vector2 screenSize;
	private Vector3 cameraPos;


	// Use this for initialization
	void Start () {
		cameraPos = Camera.main.transform.position;
		screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), 
			Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
		screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)), 
			Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

		topCol.transform.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
		topCol.transform.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + 
			(topCol.transform.localScale.y * 0.5f), zPos);

		bottomCol.transform.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
		bottomCol.transform.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - 
			(bottomCol.transform.localScale.y * 0.5f), zPos);

		leftCol.transform.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
		leftCol.transform.position = new Vector3(cameraPos.x - screenSize.x - 
			(leftCol.transform.localScale.x * 0.5f), cameraPos.y, zPos);

		rightCol.transform.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
		rightCol.transform.position = new Vector3(cameraPos.x + screenSize.x +
			(rightCol.transform.localScale.x * 0.5f), cameraPos.y, zPos);
		
	}
	

}
