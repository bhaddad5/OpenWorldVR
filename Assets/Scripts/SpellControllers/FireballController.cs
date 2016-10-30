using UnityEngine;
using System.Collections;

public class FireballController : DamageDealer
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

	protected override bool HandleBlocked(StrikeBlocker blocker)
	{
		base.HandleBlocked(blocker);
		Destroy(gameObject);
		return true;
	}

	protected override bool HandleHit(DamageTaker damageTaker)
	{
		base.HandleHit(damageTaker);

		damageTaker.TakeDamage(damage);
		Destroy(gameObject);

		return true;
	}
}
