using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	public enum State
	{
		Stand,
		Idle,
		Walk,
		Run,
		Fall,
		Fight
	}

	[SerializeField]
	private int maxSpeed = 3;
	private Rigidbody2D rbody2d;
	private GroundCheck groundCheck;


	// Use this for initialization
	void Start () 
	{
		rbody2d = GetComponent<Rigidbody2D> ();
		groundCheck = GetComponent<GroundCheck> ();
	}
		

	// Funtion handles players direction
	void HandleDirection()
	{
		if (transform.localScale.x > 0 && Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			
		} else if (transform.localScale.x < 0 && Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			
		}
		
	}

	// Function handle characters horizontal movements
	void HandleHMovements()
	{
		float h = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{

			rbody2d.velocity = new Vector2 (maxSpeed * h, rbody2d.velocity.y);

		} else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			rbody2d.velocity = new Vector2 (maxSpeed * h, rbody2d.velocity.y);
	
		} 
	}

	// Function handles characters vertical movements
	void HandleVMovements()
	{
		if (Input.GetKeyDown (KeyCode.Space) && groundCheck.onGround == true) {
			rbody2d.velocity = new Vector2 (rbody2d.velocity.x, maxSpeed * 2);

		}
	
	}
		

	// Update is called once per frame
	void Update()
	{
		HandleDirection ();
		//HandleAnimation ();
		//GroundCheck ();

	}
		

	// FixedUpdate is called once per frame at same interval of time
	void FixedUpdate () 
	{
		
		HandleHMovements ();
		HandleVMovements ();

	}
}
