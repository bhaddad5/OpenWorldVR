using System;
using UnityEngine;
using System.Collections;

public class DamageReciever : MonoBehaviour
{
	public float damageMultiplier = 1.0f;

	private DamageHandler damageHandler;

	void Start()
	{
		damageHandler = gameObject.GetComponentInAllParents<DamageHandler>();
	}

	public void RecieveHit(float damage)
	{
		if(damageHandler != null)
			damageHandler.TakeDamage(damage*damageMultiplier);
	}
}
