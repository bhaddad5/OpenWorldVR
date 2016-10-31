using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DamageDealer : MonoBehaviour
{
	public int damage;
	public bool destroyedOnHit;
	public bool usesSpeedCutoff;

	private float minSpeedOnImpact = 0.04f;
	private float cooldownAfterHit = 1.0f;
	private float lastHitTime;
	private Transform strikeTracker;
	private Vector3 prevStrikeTrackerPos;
	private List<DamageReciever> alreadyHit = new List<DamageReciever>();

	void Start()
	{
		if (usesSpeedCutoff)
		{
			strikeTracker = transform.FindChild("StrikeTracker");
			prevStrikeTrackerPos = strikeTracker.position;
		}
	}

	void Update()
	{
		if (alreadyHit.Count > 0 && Time.time > lastHitTime + cooldownAfterHit)
		{
			DamageReciever leastDamagedObjectHit = alreadyHit[0];
			foreach (DamageReciever reciever in alreadyHit)
			{
				if (reciever.damageMultiplier < leastDamagedObjectHit.damageMultiplier)
					leastDamagedObjectHit = reciever;
			}

			leastDamagedObjectHit.RecieveHit(damage);
			lastHitTime = Time.time;

			if (destroyedOnHit)
			{
				Destroy(gameObject);
			}
		}
		alreadyHit.Clear();
		if(usesSpeedCutoff)
			prevStrikeTrackerPos = strikeTracker.position;
	}

	void OnTriggerEnter(Collider collider)
	{
		DamageReciever objectHit = collider.gameObject.GetComponent<DamageReciever>();

		bool hitValid = true;
		if (usesSpeedCutoff)
		{
			float currSpeed = Vector3.Magnitude(prevStrikeTrackerPos.VectorTo(strikeTracker.position));
			if (currSpeed < minSpeedOnImpact)
				hitValid = false;
		}

		if (objectHit != null && hitValid)
		{
			alreadyHit.Add(objectHit);
		}
	}
}
