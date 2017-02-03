using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerConstructController : MonoBehaviour
{
	public GameObject spellPrefab;
	public GameObject pieceToMove;
	private Transform spellStartTrans;
	private float distFromPlayerToAwake = 25.0f;

	protected bool firing = false;
	protected float fireTime = 4f;

	void Start()
	{
		spellStartTrans = GetComponentInChildren<Light>().transform;
	}

	// Update is called once per frame
	void Update ()
	{
		float distFromPlayer = Vector3.Magnitude(transform.position - Camera.main.transform.position);
		if (distFromPlayer <= distFromPlayerToAwake)
		{
			pieceToMove.transform.LookAt(Camera.main.transform.position);

			if (!firing)
			{
				StartCoroutine(AttackPlayer());
			}
		}
	}

	private IEnumerator AttackPlayer()
	{
		float startFireTime = Time.time;
		firing = true;
		bool playerAttacked = false;

		while (startFireTime + fireTime > Time.time)
		{
			float percentFired = (Time.time - startFireTime) / fireTime;
			if (!playerAttacked && percentFired >= 0.75f)
			{
				GameObject newSpell = Instantiate(spellPrefab, spellStartTrans.position, spellStartTrans.rotation);
				newSpell.transform.LookAt(Camera.main.transform.position);
				newSpell.GetComponent<FireballController>().SetMoveSpeed(0.1f);
				playerAttacked = true;
			}
			yield return null;
		}

		firing = false;
	}
}
