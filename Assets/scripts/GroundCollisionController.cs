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

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "player" && col.gameObject.GetComponent<Rigidbody2D> ().velocity.y > 0) {
			boxCollider2d.isTrigger = true;
		}
	}

	void OnTriggerExit2d(Collider2D col)
	{
		boxCollider2d.isTrigger = false;
	}
}

