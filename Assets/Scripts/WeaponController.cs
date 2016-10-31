using UnityEngine;
using System.Collections;

public class WeaponController : DamageDealer
{
	private float minStrikeDistance = 0.3f;
	private float minStrikeSpeed = 0.04f;

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
		else
		{
			strikeBegun = false;
		}

		float totalStrikeDist = Vector3.Magnitude(strikeTracker.position - trackerPosAtStartOfStrike);
		if (strikeBegun && totalStrikeDist >= minStrikeDistance)
		{
			if (!strikeValid)
			{
				strikeValid = true;
				Debug.Log(totalStrikeDist);
			}
		}
		else strikeValid = false;


		prevStrikeTrackerPos = strikeTracker.position;
	}

	protected override bool HandleBlocked(StrikeBlocker blocker)
	{
		base.HandleBlocked(blocker);
		bool strikeValidAtStart = strikeValid;
		
		strikeValid = false;
		strikeBegun = false;

		if (strikeValidAtStart)
			return true;
		else return false;
	}

	protected override bool HandleHit(DamageTaker damageTaker)
	{
		base.HandleHit(damageTaker);

		if (strikeValid)
		{
			damageTaker.TakeDamage(damage);
			return true;
		}
		else return false;
	}
}
