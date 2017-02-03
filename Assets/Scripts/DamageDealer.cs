using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DamageDealer : MonoBehaviour
{
	public float damage;
	private IDamageController damageController;
	private List<DamageReciever> alreadyHit = new List<DamageReciever>();

	void Update()
	{
		if (alreadyHit.Count > 0)
		{
			DamageReciever mostDamagedObjectHit = alreadyHit[0];
			foreach (DamageReciever reciever in alreadyHit)
			{
				if (reciever.damageMultiplier > mostDamagedObjectHit.damageMultiplier)
					mostDamagedObjectHit = reciever;
			}

			mostDamagedObjectHit.RecieveHit(damage);
			alreadyHit.Clear();
			damageController.HandleDamageDealt();
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		DamageReciever objectHit = collider.gameObject.GetComponent<DamageReciever>();
		if (objectHit != null)
			alreadyHit.Add(objectHit);
	}

	public void SetDamageController(IDamageController controller)
	{
		damageController = controller;
	}
}
