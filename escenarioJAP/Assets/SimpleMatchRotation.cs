using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMatchRotation : MonoBehaviour
{
	public float speedRotation,speedPosition;
	public Transform target;

	
	void LateUpdate () 
	{
		transform.position = Vector3.Lerp(transform.position,target.position, Time.deltaTime * speedPosition );
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime* speedRotation);
		
	}
}
