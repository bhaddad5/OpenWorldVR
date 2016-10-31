using System;
using UnityEngine;
using System.Collections;

public class DamageReciever : MonoBehaviour
{
	public float damageMultiplier = 1.0f;

	private DamageHandler damageHandler;

	public void RecieveHit(int damage)
	{
		if(damageHandler == null)
			damageHandler = gameObject.GetComponentInAllParents<DamageHandler>();

		damageHandler.TakeDamage(Convert.ToInt32(((float) damage)*damageMultiplier));
	}
}
