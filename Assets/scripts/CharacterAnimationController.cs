using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour
{

	private Rigidbody2D rigidBody2D;
	private Animator animator;
	private State currentState;
	private GroundCheck groundCheck;
	private enum State
	{
		Stand,
		Idle,
		Walk,
		Run,
		Fall,
		Fight,
		Die
	}


	// Use this for initialization
	void Start ()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		groundCheck = GetComponentInChildren<GroundCheck> ();
		CharacterStates(State.Stand);
	}
	


	void CharacterStates(State state)
	{
		switch(state)
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
			animator.SetFloat ("horizontalSpeed", Mathf.Abs (2));
			animator.SetBool("Ground", true);
			break;
		case State.Run:
			animator.SetFloat ("horizontalSpeed", Mathf.Abs (4));
			animator.SetBool("Ground", true);
			break;
		case State.Fall:
			animator.SetBool("Ground", false);
			break;
		case State.Fight:
			animator.SetTrigger ("Danger");
			break;
		case State.Die:
			animator.SetBool ("IsAlive", false);
			break;
		default:
			break;
		}
	}

	void SmashAnimationHandler()
	{
		if (Input.GetKeyDown (KeyCode.Z) && groundCheck.onGround == true) 
		{
			CharacterStates(State.Fight);
		}
	}

	void DeathAnimationHandler()
	{
		if ( HealthManager.isAlive == false)
		{
			CharacterStates(State.Die);
		} 
	}

	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs (rigidBody2D.velocity.x) > 0 && Mathf.Abs (rigidBody2D.velocity.x) <= 2 && groundCheck.onGround == true) 
		{
			CharacterStates (State.Walk);

		} else if (Mathf.Abs (rigidBody2D.velocity.x) > 2 && groundCheck.onGround == true) 
		{
			CharacterStates (State.Run);

		} else if (groundCheck.onGround == false) 
		{
			CharacterStates(State.Fall);
		} else if (rigidBody2D.velocity.x == 0 && groundCheck.onGround == true)
		{
			CharacterStates (State.Stand);
		}

		SmashAnimationHandler ();
		DeathAnimationHandler ();
	}
}

