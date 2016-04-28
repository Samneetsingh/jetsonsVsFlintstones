using UnityEngine;
using System.Collections;

public class MoveCameraScript : MonoBehaviour {

	private Vector3 offset;
	// Use this for initialization
	void Start () 
	{
		offset = new Vector3 (0.01f, 0f, 0f);
	
	}

	void MoveCameraPosition()
	{
		transform.position = transform.position + offset;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		MoveCameraPosition ();
	
	}
}
