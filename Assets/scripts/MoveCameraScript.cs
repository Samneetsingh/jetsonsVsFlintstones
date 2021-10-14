using UnityEngine;
using System.Collections;
using System;

public class MoveCameraScript : MonoBehaviour {

	public Transform target;
	public float relativeDistanceThreshold = 4.0f;
	public float speed = 0.005f;

	// Use this for initialization
	void Start () 
	{	
	}

	// Update is called once per frame
	void LateUpdate () 
	{	
		var relativeHorizontalPosition = Mathf.Abs(this.target.localPosition.x - this.transform.localPosition.x);
		if (relativeHorizontalPosition > this.relativeDistanceThreshold && (this.target.localPosition.x > 0 || this.transform.localPosition.x > 0)) {
			transform.position = Vector3.Lerp(transform.position, new Vector3(this.target.position.x, transform.position.y, transform.position.z), speed);
		}
	}
}
