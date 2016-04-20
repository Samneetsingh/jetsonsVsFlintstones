using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour 
{

	public bool onGround = false;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}

}
