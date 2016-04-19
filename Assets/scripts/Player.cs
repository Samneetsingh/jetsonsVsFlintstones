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
	private Animator animator;
	private Rigidbody2D rbody2d;
	private State currentState = State.Stand;
	private bool onGround = false;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
		rbody2d = GetComponent<Rigidbody2D> ();
	}
		

	// Function handles characters animation
	void HandleAnimation()
	{
		
		if (Mathf.Abs (rbody2d.velocity.x) > 0 && Mathf.Abs (rbody2d.velocity.x) < 1 && onGround == true) 
		{
			currentState = State.Walk;
		} else if (Mathf.Abs (rbody2d.velocity.x) > 1 && onGround == true && Input.GetKey(KeyCode.LeftShift)) 
		{
			currentState = State.Run;
			
		} else if (onGround == false) 
		{
			currentState = State.Fall;
			
		}

		switch(currentState)
		{
		case State.Idle:
			animator.SetTrigger ("IdleTime");
			animator.SetBool ("Ground", true);
			break;
		case State.Stand:
			animator.SetFloat ("horizontalSpeed", Mathf.Abs (0));
			animator.SetBool ("Ground", true);
			break;
		case State.Walk:
			animator.SetFloat ("horizontalSpeed", Mathf.Abs (1));
			animator.SetBool("Ground", true);
			break;
		case State.Run:
			animator.SetFloat ("horizontalSpeed", Mathf.Abs (2));
			animator.SetBool("Ground", true);
			break;
		case State.Fall:
			animator.SetBool("Ground", false);
			break;
		case State.Fight:
			animator.SetTrigger ("Danger");
			break;
		default:
			break;
		}
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
	
		} else 
		{
			currentState = State.Stand;

		}
	}

	// Function handles characters vertical movements
	void HandleVMovements()
	{
		if (Input.GetKeyDown (KeyCode.Space) && onGround == true) {
			rbody2d.velocity = new Vector2 (rbody2d.velocity.x, maxSpeed * 2);

		} else if (Input.GetKeyDown (KeyCode.Z) && onGround == true) 
		{
			currentState = State.Fight;
		
		}
	
	}

	// Function checks characters ground level
	void GroundCheck()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		Debug.Log (onGround);
	}


	// Update is called once per frame
	void Update()
	{
		HandleDirection ();
		HandleAnimation ();

	}
		

	// FixedUpdate is called once per frame at same interval of time
	void FixedUpdate () 
	{
		
		HandleHMovements ();
		HandleVMovements ();
		GroundCheck ();

	}
}
