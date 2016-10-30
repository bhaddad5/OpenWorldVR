using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageDealer : MonoBehaviour
{
	public int damage;
	private bool alreadyHit = false;

	void Update()
	{
		alreadyHit = false;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (alreadyHit)
			return;
		alreadyHit = true;

		GameObject damageText = Instantiate(Singletons.GlobalPrefabs().DamageText);
		damageText.transform.position = transform.position;
		damageText.transform.LookAt(Camera.main.transform.position);
		Text text = damageText.transform.GetChild(0).GetComponent<Text>();

		StrikeBlocker blocked = collider.gameObject.GetComponent<StrikeBlocker>();
		if (blocked != null)
		{
			if (HandleBlocked(blocked))
			{
				text.text = "Blocked";
			}
			else Destroy(text);

		}

		DamageTaker objectHit = collider.gameObject.GetComponent<DamageTaker>();
		if (objectHit != null)
		{
			if (HandleHit(objectHit))
			{
				text.text = "HIT -" + damage;
			}
			else Destroy(text);
		}
	}

	protected virtual bool HandleBlocked(StrikeBlocker blocker)	{ return false; }

	protected virtual bool HandleHit(DamageTaker damageTaker) { return false; }
}
