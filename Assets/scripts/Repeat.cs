using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour {

	public float speed = -5f;
	Vector2 startPos;
	//Vector2 Offset;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPos = Mathf.Repeat (Time.time * speed, 20);
		transform.position=startPos+ Vector2.right*newPos;

		//Offset = new Vector2 (Time.time * speed, 0);
		//GetComponent<Renderer> ().material.mainTextureOffset = Offset;
	}
}
