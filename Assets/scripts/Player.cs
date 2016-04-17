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
		Fall
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
		

	void HandleAnimation()
	{
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
		default:
			break;
		}
	}

	// Handles players direction
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

	// Handle player movements
	void HandleMovement()
	{
		float h = Input.GetAxis ("Horizontal");
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			if (Mathf.Abs(maxSpeed * h) > 1) {
				currentState = State.Run;
			} else 
			{
				currentState = State.Walk;
			}
			rbody2d.velocity = new Vector2 (maxSpeed * h, rbody2d.velocity.y);

		} else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			if (Mathf.Abs(maxSpeed * h) > 1) {
				currentState = State.Run;
			} else 
			{
				currentState = State.Walk;
			}
			rbody2d.velocity = new Vector2 (maxSpeed * h, rbody2d.velocity.y);
	
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			currentState = State.Stand;
			rbody2d.velocity = new Vector2 (rbody2d.velocity.y, maxSpeed );
		} else 
		{
			currentState = State.Stand;
		}
	}
		
	// Update is called once per frame
	void Update()
	{
		

	}

	void GroundCheck()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		//animator.SetBool ("Ground", onGround);
		
	}
	// FixedUpdate is called once per frame at same interval of time
	void FixedUpdate () 
	{
		HandleDirection ();
		HandleMovement ();
		HandleAnimation ();

	}
}
