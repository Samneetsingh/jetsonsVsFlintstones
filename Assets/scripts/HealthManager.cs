using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{

	private static int playerHealth;
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
	void Update ()
	{
		if (playerHealth < 0) 
		{
			isAlive = false;
		}
	}
}

