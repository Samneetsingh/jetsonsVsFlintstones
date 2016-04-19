using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {


	void BlastBarrel()
	{
		Destroy (gameObject);
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		BlastBarrel ();
	}
}
