using UnityEngine;
using System.Collections;

public class CharacterMovementController : MonoBehaviour {

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
	private int maxSpeed;
	private Rigidbody2D rigidBody2D;
	private GroundCheck groundCheck;


	// Use this for initialization
	void Start () 
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		groundCheck = GetComponentInChildren<GroundCheck> ();
	}
		

	// Funtion handles players direction
	void HandleDirection()
	{
		if (transform.localScale.x > 0 && Input.GetKeyDown(KeyCode.LeftArrow) && HealthManager.isAlive == true) 
		{
			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
			
		} else if (transform.localScale.x < 0 && Input.GetKeyDown(KeyCode.RightArrow) && HealthManager.isAlive == true) 
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

			rigidBody2D.velocity = new Vector2 (this.maxSpeed * h , rigidBody2D.velocity.y);

		} else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			rigidBody2D.velocity = new Vector2 (this.maxSpeed * h, rigidBody2D.velocity.y);
	
		}
			
	}

	// Function handles characters vertical movements
	void HandleVMovements()
	{
		if (Input.GetKeyDown (KeyCode.Space) && groundCheck.onGround == true) {
			rigidBody2D.velocity = new Vector2 (rigidBody2D.velocity.x, maxSpeed * 2);

		}
	
	}
		
	// Function handles characters maximum speed
	void HandleMaxSpeed()
	{
		if (Input.GetKey (KeyCode.R)) {
			this.maxSpeed = 3;
		} else 
		{
			this.maxSpeed = 2;
		}
		
	}

	// Update is called once per frame
	void Update()
	{
		HandleDirection ();
	}
		
	void HandleDeathMovement()
	{
		if (HealthManager.isAlive == false) rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
	}

	// FixedUpdate is called once per frame at same interval of time
	void FixedUpdate () 
	{
		
		HandleHMovements ();
		HandleVMovements ();
		HandleDeathMovement ();
		HandleMaxSpeed ();

	}
}
