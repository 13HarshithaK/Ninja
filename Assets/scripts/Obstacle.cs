using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-1, 0, 0) * speed * Time.deltaTime);
		
	}

	void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.gameObject.tag== "Player") {
			GameControl.instance.NinjaScored ();
		}
	}

}
