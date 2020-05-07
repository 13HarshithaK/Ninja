using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class Click : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play()
	{
		SceneManager.LoadScene("GamePlay");
	}

	public void Pause()
	{
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}


}
