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
		if (col.gameObject.tag == "Club") {
			barrelAnimator.SetTrigger ("Destroy");
			col.gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2(1.0f, 1.0f), ForceMode2D.Impulse);
			yield return new WaitForSeconds (1);
			Destroy (gameObject);

		} else if (col.gameObject.tag == "Player") 
		{
			HealthManager.ReduceHealth (35);
			//col.rigidbody.AddForce (col.transform.localScale * 2, ForceMode2D.Impulse);
		}

	}
}
