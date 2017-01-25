using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour
{
	private float movementSpeed = 0.4f;
	private float createdTime;
	private float lifespan = 5f;
	private Transform controllingStaff;

	// Use this for initialization
	void Start ()
	{
		createdTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(createdTime + lifespan <= Time.time)
			Destroy(gameObject);

		if (controllingStaff != null)
			transform.position = Vector3.MoveTowards(transform.position,
				controllingStaff.transform.position + controllingStaff.transform.forward * 10000, movementSpeed);
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, transform.forward * 10000, movementSpeed);
		}
	}

	public void SetControllingStaff(Transform staff)
	{
		controllingStaff = staff;
	}

	public void SetMoveSpeed(float newSpeed)
	{
		movementSpeed = newSpeed;
	}
}
