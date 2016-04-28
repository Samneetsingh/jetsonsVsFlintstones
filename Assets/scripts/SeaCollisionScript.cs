using UnityEngine;
using System.Collections;

public class SeaCollisionScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		HealthManager.ReduceHealth (100);
		Destroy (col.gameObject);
	}
}

