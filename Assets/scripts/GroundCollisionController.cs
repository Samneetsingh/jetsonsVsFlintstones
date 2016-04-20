using UnityEngine;
using System.Collections;

public class GroundCollisionController : MonoBehaviour
{
	private BoxCollider2D boxCollider2d;
	// Use this for initialization
	void Start ()
	{
		boxCollider2d = GetComponent<BoxCollider2D> ();
	
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground") {
			boxCollider2d.isTrigger = true;
		} else if (col.gameObject.tag == "Player") {
			boxCollider2d.isTrigger = false;
		} 
	}
		

	void OnTriggerExit2D(Collider2D col)
	{
		boxCollider2d.isTrigger = true; 
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			boxCollider2d.isTrigger = true;
		} else if (col.gameObject.tag == "Player") {
			boxCollider2d.isTrigger = false;
		} 
	}

	void OnCollisionExit2D(Collision2D col)
	{
		boxCollider2d.isTrigger = true;
	}
}

