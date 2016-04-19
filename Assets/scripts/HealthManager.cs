using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{

	private int playerHealth;
	private Vector3 spawnPosition;
	// Use this for initialization
	void Start ()
	{
		playerHealth = 100;
		spawnPosition = new Vector3 (0.24f, 3.89f, 0f);
	}


	void ReduceHealth()
	{
		this.playerHealth -= 50;
	}

	void GainHealth()
	{
		
	}

	void Respawn()
	{
		transform.position = spawnPosition;
		playerHealth = 100;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Danger") 
		{
			ReduceHealth ();
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (playerHealth < 0) 
		{
			Respawn ();
		}
	}
}

