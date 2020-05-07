using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour {
	public GameObject GrassSprite;                                 //The column game object.
	public int grassPoolSize = 3;                                  //How many columns to keep on standby.
	public float spawnRate = 5f;                                    //How quickly columns spawn.
	public float columnMin = -1f;                                   //Minimum y value of the column position.
	public float columnMax = 3f;                                  //Maximum y value of the column position.

	private GameObject[] grass;                                   //Collection of pooled columns.
	private int currentgrass = 0;                                  //Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		grass = new GameObject[grassPoolSize];
		//Loop through the collection... 
		for(int i = 0; i < grassPoolSize; i++)
		{
			//...and create the individual columns.
			grass[i] = (GameObject)Instantiate(GrassSprite, objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{   
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(columnMin, columnMax);

			//...then set the current column to that position.
			grass[currentgrass].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentgrass ++;

			if (currentgrass >= grassPoolSize) 
			{
				currentgrass = 0;
			}
		}
	}



}
