using UnityEngine;
using System.Collections;

public class WeaponController : DamageDealer
{
	private float minStrikeDistance = 0.1f;
	private float minStrikeSpeed = 0.03f;

	private float currStrikeDistance = 0f;
	private Transform strikeTracker;
	private Vector3 prevStrikeTrackerPos;
	private Vector3 trackerPosAtStartOfStrike;
	private bool strikeBegun;
	private bool strikeValid;

	// Use this for initialization
	void Start ()
	{
		strikeTracker = transform.FindChild("StrikeTracker");
		prevStrikeTrackerPos = strikeTracker.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float currFrameStrikeDist = Vector3.Magnitude(strikeTracker.position - prevStrikeTrackerPos);
		if (currFrameStrikeDist > minStrikeSpeed)
		{
			if (!strikeBegun)
			{
				trackerPosAtStartOfStrike = strikeTracker.position;
			}
			strikeBegun = true;
		}
		else strikeBegun = false;

		float totalStrikeDist = Vector3.Magnitude(strikeTracker.position - trackerPosAtStartOfStrike);
		if (strikeBegun && totalStrikeDist >= minStrikeDistance)
		{
			strikeValid = true;
		}
		else strikeValid = false;


		prevStrikeTrackerPos = strikeTracker.position;
	}

	protected override void HandleBlocked(StrikeBlocker blocker)
	{
		base.HandleBlocked(blocker);
		strikeValid = false;
		strikeBegun = false;
	}

	protected override int HandleHit(DamageTaker damageTaker)
	{
		if (strikeValid)
		{
			damageTaker.TakeDamage(damage);
		}

		return base.HandleHit(damageTaker);
	}
}
