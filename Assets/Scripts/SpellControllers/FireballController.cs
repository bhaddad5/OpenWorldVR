using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour
{
	private float movementSpeed = 0.3f;
	private float createdTime;
	private float lifespan = 10f;
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
			Destroy(this);

		transform.position = Vector3.MoveTowards(transform.position, controllingStaff.transform.position + controllingStaff.transform.forward*1000, movementSpeed);
	}

	public void SetControllingStaff(Transform staff)
	{
		controllingStaff = staff;
	}
}
