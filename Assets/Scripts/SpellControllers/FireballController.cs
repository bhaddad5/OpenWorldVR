using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour
{
	private Vector3 movementDirection;
	private float movementSpeed = 0.3f;
	private float createdTime;
	private float lifespan = 10f;

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

		transform.position = transform.position + movementDirection.normalized*movementSpeed;
	}

	public void SetMoveDir(Vector3 dir)
	{
		movementDirection = dir;
	}
}
