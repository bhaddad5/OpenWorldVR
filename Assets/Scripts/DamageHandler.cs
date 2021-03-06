﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour
{
	public float HP;

	private float textYOffset = 1.0f;

	void Start()
	{
		Bounds combinedBounds = new Bounds();
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers)
		{
			if(renderer != GetComponent<Renderer>())
				combinedBounds.Encapsulate(renderer.bounds);
		}

		textYOffset = combinedBounds.max.y - transform.position.y;
	}

	public void TakeDamage(float damage)
	{
		if (gameObject.name == "[CameraRig]")
		{
			HP -= damage;
			if (damage > 0)
			{
				SteamVR_Controller.Input(0).TriggerHapticPulse(2000);
				SteamVR_Controller.Input(1).TriggerHapticPulse(2000);
			}
			
			return;
		}

		GameObject damageText = Instantiate(Singletons.GlobalPrefabs().DamageText);
		damageText.transform.position = transform.position + new Vector3(0, textYOffset, 0);
		damageText.transform.LookAt(Camera.main.transform.position);
		Text text = damageText.transform.GetChild(0).GetComponent<Text>();

		if (damage.Equals(0))
		{
			text.text = "BLOCKED";
		}
		else text.text = "HIT -" + damage;


		HP -= damage;
		if (HP <= 0)
		{
			Destroy(gameObject);
		}
	}
}
