using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour 
{
	private CharacterController controller;
	
	public float speed;
	public float jumpSpeed;
	
	public Animator animator;
	private Vector3 moveDirection;
	public float gravity = 50;
	
	public float rotationSpeed = 150;
	
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	void Update () 
	{
		
	
		if (controller.isGrounded) 
		{
			transform.Rotate(Vector3.up*rotationSpeed*Input.GetAxis("Horizontal")*Time.deltaTime);
			moveDirection = new Vector3(0/*Input.GetAxis("Horizontal")*/,0,Input.GetAxis("Vertical"));		
			if(moveDirection.magnitude>1)
			{
				moveDirection.Normalize();
			}
			animator.SetFloat("Velocidad", moveDirection.magnitude);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpSpeed;
				animator.SetTrigger("Brinco");
			}
			else
			{
				if(Input.GetKeyDown(KeyCode.Q))
				{
					animator.SetTrigger("Ataque");
				}
			}
            
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		
	}
	
}







