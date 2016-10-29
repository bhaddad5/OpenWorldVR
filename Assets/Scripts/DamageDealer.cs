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
			text.text = "Blocked";
			HandleBlocked(blocked);
		}

		DamageTaker objectHit = collider.gameObject.GetComponent<DamageTaker>();
		if (objectHit != null)
		{
			int damage = HandleHit(objectHit);
			text.text = "HIT -" + damage;
		}
	}

	protected virtual void HandleBlocked(StrikeBlocker blocker)	{}

	protected virtual int HandleHit(DamageTaker damageTaker)
	{
		return damage;
	}
}
