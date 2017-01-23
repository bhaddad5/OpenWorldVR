using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlyingConstructMovementController : MonoBehaviour
{
	public GameObject spellPrefab;

	private float fireTime = 2f;
	private float moveTime = 2f;
	private float speedOfMove = 4f;
	private float maxDistFromPlayer = 20f;

	private bool moving = false;
	private bool firing = false;

	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform);

		if (!moving && !firing)
		{
			Vector3 pointToMoveTo = FindMovePoint(0, 50);
			StartCoroutine(MoveToPoint(pointToMoveTo));
		}
		
	}

	private Vector3 FindMovePoint(int currSanity, int maxSanity)
	{
		Vector3 testDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		testDir.Normalize();

		Ray moveRay = new Ray(transform.position, testDir);
		if (!Physics.Raycast(moveRay, moveTime*speedOfMove))
		{
			Vector3 endPos = transform.position + testDir*(moveTime*speedOfMove);
			float endDistToPlayer = Vector3.Magnitude(Camera.main.transform.position - endPos);
			Ray playerHitRay = new Ray(endPos, Camera.main.transform.position - endPos);
			RaycastHit info;
			if (endDistToPlayer <= maxDistFromPlayer && Physics.Raycast(playerHitRay, out info))
			{
				if (info.collider.name == "PlayerBody")
				{
					return endPos;
				}
			}
		}
		if(currSanity <= maxSanity)
			return FindMovePoint(currSanity + 1, maxSanity);

		return transform.position;
	}

	private IEnumerator MoveToPoint(Vector3 targetPos)
	{
		moving = true;
		Vector3 startPos = transform.position;
		float startMoveTime = Time.time;
		
		while (startMoveTime + moveTime > Time.time)
		{
			float percentTraveled = (Time.time - startMoveTime)/ moveTime;
			transform.position = Vector3.Lerp(startPos, targetPos, percentTraveled);
			yield return null;
		}
		moving = false;
		StartCoroutine(FireAtPlayer());
	}

	private IEnumerator FireAtPlayer()
	{
		float startFireTime = Time.time;
		firing = true;
		bool spellFired = false;

		while (startFireTime + fireTime > Time.time)
		{
			float percentFired = (Time.time - startFireTime)/moveTime;
			if (!spellFired && percentFired >= 0.75f)
			{
				GameObject newSpell = Instantiate(spellPrefab, transform.position + transform.forward.normalized, transform.rotation);
				newSpell.GetComponent<FireballController>().SetMoveSpeed(0.1f);
				spellFired = true;
			}
			yield return null;
		}

		firing = false;
	}
}
