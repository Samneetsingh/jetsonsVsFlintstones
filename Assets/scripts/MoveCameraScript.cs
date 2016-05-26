using UnityEngine;
using System.Collections;

public class MoveCameraScript : MonoBehaviour {

	//private CharacterMovementController controller;
	private Vector2 velocity;
	private GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");


	}

	/*void CheckCameraSpeed()
	{
		if (Input.GetKey (KeyCode.R)) {
			cameraSpeed = 2;
		} else 
		{
			cameraSpeed = 1;
		}
	}*/

	void MoveCameraPosition()
	{
		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			transform.position = transform.position + new Vector3 (cameraVelocity, 0f, 0f);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position = transform.position + new Vector3 (-cameraVelocity, 0f, 0f);
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Debug.Log (cameraVelocity);
		//CheckCameraSpeed ();
		MoveCameraPosition ();
	
	}
}
