using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {


	private Animator barrelAnimator;
	// Use this for initialization

	void Start ()
	{
		barrelAnimator = GetComponent<Animator> ();
	}

	void Update()
	{
		
		
	}


	IEnumerator OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag == "Club") {
			barrelAnimator.SetTrigger ("Destroy");
			yield return new WaitForSeconds (1);
			Destroy (gameObject);

		} else if (col.gameObject.tag == "Player") 
		{
			HealthManager.ReduceHealth (10);
		}


	}
}
