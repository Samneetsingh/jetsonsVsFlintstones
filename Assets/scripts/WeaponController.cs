using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Danger") 
		{
			//Rigidbody2D rd = col.GetComponent<Rigidbody2D> ();
			//Vector2 f = new Vector2(6f, 6f);
			//rd.AddForce (f, ForceMode2D.Impulse);
		}


	}
}
	