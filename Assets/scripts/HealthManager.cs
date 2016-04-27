using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{

	private const int MAX_HEALTH = 100;
	private const int MIN_HEALTH = 0;
	public static int playerHealth;
	public static bool isAlive;

	// Use this for initialization
	void Start ()
	{
		playerHealth = 100;
		isAlive = true;
	}


	public static void ReduceHealth(int value)
	{
		playerHealth -= value;
	}

	public static void GainHealth(int value)
	{
		playerHealth += value;
	}
		

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (playerHealth < MIN_HEALTH) 
		{
			isAlive = false;
		}
		else if(playerHealth > MAX_HEALTH) 
		{
			playerHealth = MAX_HEALTH;
		}
	}
}

